using System.ComponentModel.DataAnnotations;

namespace Travel_Reimbursement.CustomValidation
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimumValue) : base(typeof(DateTime),minimumValue,DateTime.Now.ToShortDateString())
        {
        }
    }
}