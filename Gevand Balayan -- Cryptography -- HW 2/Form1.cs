using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gevand_Balayan____Cryptography____HW_2
{
    public partial class Form1 : Form
    {
        #region public variables
        //[1, 0, 1, 1] => x^3 + x + 1
        public List<int[]> equations;
        public List<int[]> irreduceables;
        public List<int[]> primitives;
        //degree passed in
        public int n;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInput.Text, out n))
            {
                MessageBox.Show("Input must be an integer");
                txtInput.Focus();
                return;
            }
            //generate all possible equations
            equations = generateAllPolunomials(n);
            //find the irreducibles
            irreduceables = findIrreducibles(equations, n);
            lblIrreducible.Text = "IRREDUCIBLES " + irreduceables.Count;
            //find the primitives
            primitives = findPrimitives(irreduceables, n);
            lblPrimitive.Text = "PRIMITIVES " + primitives.Count;
            //////////////////////////////////////////////
            var prettyEquations = equationForm(equations);
            lstOuput.DataSource = prettyEquations;


        }
        private List<int[]> generateAllPolunomials(int degree)
        {
            List<int[]> returnedList = new List<int[]>();
            double count = Math.Pow(2, degree);
            for (int i = 0; i < count; i++)
            {
                var binaryRep = Convert.ToString(i, 2).ToCharArray();
                Array.Reverse(binaryRep);
                int[] equation = new int[degree + 1];
                equation[degree] = 1; //degree is always at one, everythign else is a combination of 0 and 1
                for (int j = 0; j < binaryRep.Length; j++)
                {
                    equation[j] = Convert.ToInt32(binaryRep[j].ToString());
                }
                returnedList.Add(equation);
            }
            return returnedList;
        }
        private List<int[]> findIrreducibles(List<int[]> input, int degree)
        {
            List<int[]> returnedList = new List<int[]>();
            foreach (var candidate in input)
            {

                bool keep = true;
                for (int i = 1; i < degree; i++)
                {
                    List<int[]> temp = generateAllPolunomials(i);
                    foreach (var equation in temp)
                    {
                        if (EuclideanDivision(candidate, equation, equation) == 0)
                        {
                            keep = false;
                            break;
                        }
                    }
                    if (!keep)
                        break;
                }
                if (keep)
                    returnedList.Add(candidate);
            }

            return returnedList;
        }
        private List<int[]> findPrimitives(List<int[]> input, int degree)
        {
            List<int[]> returnedList = new List<int[]>();
            int max = (int)Math.Pow(2, degree) - 1;
            foreach (var equation in input)
            {
                bool keep = true;
                for (int i = max; i > degree; i--)
                {
                    int[] binomial = new int[i];
                    binomial[0] = 1; binomial[i - 1] = 1;
                    if (EuclideanDivision(binomial, equation, equation) == 0)
                    {
                        keep = false;
                        break;
                    }
                }
                if (keep)
                    returnedList.Add(equation);
            }
            return returnedList;
        }
        private List<string> equationForm(List<int[]> input)
        {
            List<string> output = new List<string>();
            foreach (var equation in input)
            {
                var outputeq = "";
                for (int k = equation.Length - 1; k >= 0; k--)
                {
                    if (equation[k] == 1)
                    {
                        if (outputeq.Length == 0)
                            outputeq += "x^" + k;
                        else
                            outputeq += "+x^" + k;
                    }
                }
                output.Add(outputeq.Replace("+x^0", "+1"));
            }
            return output;
        }

        private void lstOuput_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var prettyIrreduceableEquations = equationForm(irreduceables);
            var prettyPrimitiveEquations = equationForm(primitives);
            if (prettyPrimitiveEquations.Contains(lstOuput.Items[e.Index].ToString()))
                e.Graphics.DrawString(lstOuput.Items[e.Index].ToString(), lstOuput.Font, Brushes.Blue, e.Bounds);
            else if (prettyIrreduceableEquations.Contains(lstOuput.Items[e.Index].ToString()))
                e.Graphics.DrawString(lstOuput.Items[e.Index].ToString(), lstOuput.Font, Brushes.Green, e.Bounds);
            else
                e.Graphics.DrawString(lstOuput.Items[e.Index].ToString(), lstOuput.Font, Brushes.Black, e.Bounds);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblIrreducible.BackColor = System.Drawing.Color.LightGreen;
            lblPrimitive.BackColor = System.Drawing.Color.LightBlue;
        }

        private int EuclideanDivision(int[] a, int[] b, int[] c)
        {
            if (a.Length > b.Length)
            {
                return EuclideanDivision(b, a, c);
            }
            else if (b.Length > a.Length)
            {
                //shifting
                var temp = new int[b.Length];
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    var index = i - (b.Length - a.Length);
                    if (index >= 0)
                        temp[i] = a[index];

                }
                return EuclideanDivision(temp, b, c);
            }
            else
            {
                //Xor, get remainder, divide again.
                int[] temp = new int[b.Length];
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    temp[i] = a[i] ^ b[i];
                }
                for (int i = temp.Length - 1; i >= 0; i--)
                {
                    if (temp[i] == 0)
                        Array.Resize(ref temp, temp.Length - 1);
                    else
                        break;
                }
                if (temp.Length == 0)
                    return 0;
                if (temp.Length == 1 && temp[0] == 1)
                    return 1;
                return EuclideanDivision(c, temp, c.Length < temp.Length ? c : temp);
            }
        }
    }
}
