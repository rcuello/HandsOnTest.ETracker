using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HandsOnTest.ETracker.CsvParser
{
    public class TextFields
    {
        private string[] items;
        private CultureInfo culture;
        private long lineNumber;
       
        /// <summary>
        /// Initializes a new instance of TextFields from an array of strings indicating
        /// the culture-specific information to use for parsing the 
        /// </summary>
        /// <param name="values">The array of string containing the values for each field.</param>
        /// <param name="cultureInfo">The culture-specific information to use for parsing the </param>
        public TextFields(string[] values, CultureInfo cultureInfo)
        {
            //this.lineNumber = lineNumber;
            this.items = (string[])values.Clone();
            this.culture = cultureInfo;
        }

        /// <summary>
        /// Gets the number of fields in the current record.
        /// </summary>
        public int Count
        {
            get { return items.Length; }
        }

        public bool Exists(int ordinal)
        {
            return (items.Length - 1 >= ordinal);
        }


        /// <summary>
        /// Gets the string value of the specified field.
        /// </summary>
        /// <param name="i">The zero-based field ordinal.</param>
        /// <returns>The value of the field.</returns>
        /// <exception cref="IndexOutOfRange">
        /// The index passed was outside the range of 0 through FieldCount.
        /// </exception>
        public string GetString(int ordinal, string indexName = null)
        {
            //ValidateColumnNotFound(ordinal, indexName: indexName);
            if (items.Length - 1 < ordinal) return null;
            return items[ordinal];
        }

        
        public object Get(Type @type, string columnName, string documentType, TextFieldAttribute attribute)
        {
            int ordinal = attribute.Position;

            bool existsColumn = Exists(ordinal);
            string valor = GetString(ordinal, indexName: columnName);

            return Convert.ChangeType(GetString(ordinal, indexName: columnName), @type);
        }


        #region Extended

        public TEntity To<TEntity>() where TEntity : new()
        {
            var entity = new TEntity();
            PropertyInfo[] properties = typeof(TEntity).GetProperties();
            //System.Threading.Tasks.Parallel.ForEach(properties, (property) =>
            //{
            //    if (property.GetCustomAttributes(true).FirstOrDefault() is TextFieldAttribute attribute)
            //    {
            //        var @type = property.PropertyType;
            //        var @value = this.Get(type: @type, columnName: property.Name, documentType: null, attribute: attribute);
            //        property.SetValue(entity, @value);
            //    }
            //});

            foreach (var property in properties)
            {
                if (property.GetCustomAttributes(true).FirstOrDefault() is TextFieldAttribute attribute)
                {
                    var @type = property.PropertyType;
                    var @value = this.Get(type: @type, columnName: property.Name, documentType: null, attribute: attribute);
                    property.SetValue(entity, @value);
                }
            }


            return entity;
        }


        
        #endregion
    }
}
