﻿using System;
using System.IO;
using Parquet.Data;

namespace Parquet.Data.Concrete
{
   class Int16DataType : BasicPrimitiveDataType<short>
   {
      public Int16DataType() : base(DataType.Short, Thrift.Type.INT32, Thrift.ConvertedType.INT_16)
      {

      }

      protected override short ReadOne(BinaryReader reader)
      {
         return reader.ReadInt16();
      }

      protected override void WriteOne(BinaryWriter writer, short value)
      {
         writer.Write(value);
      }
   }
}