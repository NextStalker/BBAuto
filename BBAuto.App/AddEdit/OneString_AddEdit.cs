using System;
using System.Windows.Forms;
using BBAuto.Logic.Static;

namespace BBAuto.App.AddEdit
{
  public partial class OneString_AddEdit : Form
  {
    private int _id = 0;
    private string _dicName;

    public OneString_AddEdit(string dicName)
    {
      InitializeComponent();

      _dicName = dicName;
      this.Text = "Добавление";
    }

    public OneString_AddEdit(string dicName, int id, string name)
    {
      InitializeComponent();

      _dicName = dicName;
      _id = id;
      tbName.Text = name;

      this.Text = "Редактирование";
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      try
      {
        trySave();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void trySave()
    {
      OneStringDictionary.save(_dicName, _id, tbName.Text);
      this.Close();
    }
  }
}
