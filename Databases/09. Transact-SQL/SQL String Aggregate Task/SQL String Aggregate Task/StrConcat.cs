// SOURCE
// http://developmentsimplyput.blogspot.bg/2013/03/creating-sql-custom-user-defined.html
// https://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/
namespace SQL_String_Aggregate_Task
{
    using System;
    using System.Data.SqlTypes;
    using System.Text;

    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
       Microsoft.SqlServer.Server.Format.UserDefined,
       IsInvariantToDuplicates = false, // receiving the same value again changes the result
       IsInvariantToNulls = true,      // receiving a NULL value changes the result
       IsInvariantToOrder = true,       // the order of the values doesn't affect the result
       IsNullIfEmpty = true,            // if no values are given the result is null
       MaxByteSize = -1,
       Name = "CountNulls"              // name of the aggregate
    )]
    public struct StrConcat
    {
        private string resultOfConcatenation;
        private StringBuilder builder;
        private string delimeter;

        public void Init()
        {
            resultOfConcatenation = string.Empty;
            builder = new StringBuilder();
            delimeter = ",";
        }

        public void Accumulate(SqlString value)
        {
            if (!value.IsNull)
            {
                builder.Append(value);
            }
        }

        public void Merge(StrConcat group)
        {
            if (builder.Length > 0 && group.builder.Length > 0)
            {
                builder.Append(delimeter);
            }

            builder.Append(group.builder.ToString());
        }

        public SqlString Terminate()
        {
            resultOfConcatenation = builder.ToString();
            return new SqlString(resultOfConcatenation);
        }
    }
}
