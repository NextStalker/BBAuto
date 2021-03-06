using System;
using System.Windows.Forms;
using BBAuto.Logic.Entities;
using BBAuto.Logic.Lists;

namespace BBAuto.App.FormsForDriver
{
  public partial class formFuelCardDriver : Form
  {
    private Driver _driver;

    public formFuelCardDriver(Driver driver)
    {
      InitializeComponent();

      _driver = driver;
    }

    private void formFuelCardDriver_Load(object sender, EventArgs e)
    {
      FuelCardDriverList fuelCardDriverList = FuelCardDriverList.getInstance();

      dgvDriverCar.DataSource = fuelCardDriverList.ToDataTable(_driver);
      dgvDriverCar.Columns[0].Visible = false;
      dgvDriverCar.Columns[1].Visible = false;
      dgvDriverCar.Columns[3].Visible = false;
    }
  }
}
