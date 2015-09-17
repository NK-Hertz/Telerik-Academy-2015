using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    public class DateUtils
    {
        public DateUtils() { }

        public bool IsOlderThan(Student studentA, Student studentB)
        {
            DateTime firstDate =
                DateTime.Parse(studentA.OtherInfo.Substring(studentA.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(studentB.OtherInfo.Substring(studentB.OtherInfo.Length - 10));
            return firstDate > secondDate;
        }
    }
}
