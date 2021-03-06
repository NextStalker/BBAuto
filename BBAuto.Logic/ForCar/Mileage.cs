using System;
using System.Data;
using BBAuto.Logic.Abstract;
using BBAuto.Logic.Common;
using BBAuto.Logic.Entities;
using BBAuto.Logic.Lists;

namespace BBAuto.Logic.ForCar
{
  public class Mileage : MainDictionary
  {
    private int _count;

    public string Count => _count == 0 ? string.Empty : _count.ToString();

    public DateTime Date { get; set; }
    public Car Car { get; private set; }

    internal Mileage(Car car)
    {
      Car = car;
      Date = DateTime.Today.Date;
      Id = 0;
    }

    public Mileage(DataRow row)
    {
      fillFields(row);
    }

    private void fillFields(DataRow row)
    {
      Id = Convert.ToInt32(row.ItemArray[0]);

      int idCar;
      int.TryParse(row.ItemArray[1].ToString(), out idCar);
      Car = CarList.getInstance().getItem(idCar);

      DateTime date;
      DateTime.TryParse(row.ItemArray[2].ToString(), out date);
      Date = date;

      int.TryParse(row.ItemArray[3].ToString(), out _count);
    }

    public override void Save()
    {
      Id = Convert.ToInt32(Provider.Insert("Mileage", Id, Car.Id, Date, _count));

      MileageList mileageList = MileageList.getInstance();
      mileageList.Add(this);
    }

    internal override object[] GetRow()
    {
      return new object[3] {Id, Date, _count};
    }

    internal override void Delete()
    {
      Provider.Delete("Mileage", Id);
    }

    internal DateTime MonthToString()
    {
      MyDateTime myDate = new MyDateTime(Date.ToShortDateString());

      return (_count == 0) ? new DateTime(DateTime.Today.Year, 1, 31) : Date;
    }

    public void SetCount(string value)
    {
      Mileage mileage = GetPrev();

      int count;

      if (!int.TryParse(value.Replace(" ", ""), out count))
        throw new InvalidCastException();

      int prevCount = 0;
      if (mileage != null)
      {
        int.TryParse(mileage.Count, out prevCount);

        if ((count < prevCount) && (Date > mileage.Date))
          throw new InvalidConstraintException();
      }

      if (count >= 1000000)
        throw new OverflowException();

      _count = count;
    }

    public string PrevToString()
    {
      Mileage mileage = GetPrev();

      return (mileage == null) ? "0" : mileage.ToString();
    }

    private Mileage GetPrev()
    {
      return MileageList.getInstance().getItem(Car, this);
    }

    public override string ToString()
    {
      return (Count == string.Empty)
        ? "(нет данных)"
        : string.Concat(MyString.GetFormatedDigitInteger(Count), " км от ", Date.ToShortDateString());
    }
  }
}
