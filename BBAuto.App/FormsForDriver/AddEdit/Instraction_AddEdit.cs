using System;
using System.Windows.Forms;
using BBAuto.App.Events;
using BBAuto.Logic.ForDriver;

namespace BBAuto.App.FormsForDriver.AddEdit
{
  public partial class Instraction_AddEdit : Form
  {
    private Instraction _instraction;

    private WorkWithForm _workWithForm;

    public Instraction_AddEdit(Instraction instraction)
    {
      InitializeComponent();

      _instraction = instraction;
    }

    private void Instraction_AddEdit_Load(object sender, EventArgs e)
    {
      fillFields();

      _workWithForm = new WorkWithForm(this.Controls, btnSave, btnClose);
      _workWithForm.SetEditMode(_instraction.Id == 0);
    }

    private void fillFields()
    {
      tbNumber.Text = _instraction.Name;
      dtpDate.Value = Convert.ToDateTime(_instraction.Date);
      TextBox tbFile = (TextBox) ucFile.Controls["tbFile"];
      tbFile.Text = _instraction.File;
    }

    private void save_Click(object sender, EventArgs e)
    {
      if (_workWithForm.IsEditMode())
      {
        _instraction.Date = dtpDate.Value.Date.ToShortDateString();
        _instraction.Name = tbNumber.Text;

        TextBox tbFile = (TextBox) ucFile.Controls["tbFile"];
        _instraction.File = tbFile.Text;

        _instraction.Save();
      }
      else
        _workWithForm.SetEditMode(true);
    }
  }
}
