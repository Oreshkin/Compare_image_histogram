using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace test_image_rec
{
    public partial class Traning : Form
    {
        private readonly List<List<int[]>> _gistogramRef = new List<List<int[]>>();
        private readonly List<string> _standartNameRef = new List<string>();
        private readonly int[] _histogram = new int[1331];

        public Traning(ref List<string> standartName, ref List<List<int[]>> gistograms, int[] gist)
        {
            InitializeComponent();
            _gistogramRef = gistograms;
            _standartNameRef = standartName;
            _histogram = gist;
            
            button1.Text = standartName[0];
            button2.Text = standartName[1];
            button3.Text = standartName[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _gistogramRef[0].Add(_histogram);
            SystemHelper.Serialize(_standartNameRef, _gistogramRef);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _gistogramRef[1].Add(_histogram);
            SystemHelper.Serialize(_standartNameRef, _gistogramRef);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _gistogramRef[2].Add(_histogram);
            SystemHelper.Serialize(_standartNameRef, _gistogramRef);
            Close();
        }



    }
}
