﻿using System;
using System.Collections.Generic;
using System.Text;
using Parquet.Data;
using Xunit;

namespace Parquet.Test
{
   public class RepeatableFieldsTest
   {
      [Fact]
      public void Repeatable_field_writes_reads()
      {
         var ds = new DataSet(new Field<int>("id"), new Field<IEnumerable<string>>("repeats"));
         ds.Add(1, new[] { "one", "two", "three" });

         Assert.Equal("{1;[one;two;three]}", DataSetGenerator.WriteRead(ds)[0].ToString());
      }

      [Fact]
      public void Repeatable_field_with_no_values_writes_reads()
      {
         var ds = new DataSet(new Field<int>("id"), new Field<IEnumerable<string>>("repeats"));
         ds.Add(1, new string[0]);

         DataSet ds1 = ds.WriteRead();

         Assert.Equal("{1;[one;two;three]}", ds1[0].ToString());
      }
   }
}
