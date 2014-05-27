﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace LiveSplit.GoLSplit
{
    public partial class MapTimesForm : Form
    {
        public MapTimesForm()
        {
            InitializeComponent();
        }

        public void AddMapTime(string map, string time)
        {
            this.lvMapTimes.Items.Add(new ListViewItem(new[] {map, time}));
        }

        public void Reset()
        {
            this.lvMapTimes.Items.Clear();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var str = new StringBuilder();

            foreach (ListViewItem lvi in this.lvMapTimes.Items)
            {
                str.AppendLine(lvi.SubItems[0].Text + " " + lvi.SubItems[1].Text);
            }

            try
            {
                Clipboard.SetText(str.ToString());
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
