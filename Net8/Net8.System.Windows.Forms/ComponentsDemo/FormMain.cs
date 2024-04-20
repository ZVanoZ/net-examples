namespace ComponentsDemo
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDataGridView_Click(object sender, EventArgs e)
        {
             (new DataGridViewDemo.Form1()).Show(this);
        }
    }
}
