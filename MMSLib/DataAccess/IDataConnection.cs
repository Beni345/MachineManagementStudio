using System;
using System.Collections.Generic;

namespace MMSLib.DataAccess
{
    public interface IDataConnection
    {
        void DeleteRecord<T>(string table, Guid id);
        void InsertRecord<T>(string table, T record);
        T LoadRecordById<T>(string table, Guid id);
        List<T> LoadRecords<T>(string table);
        void UpsertRecord<T>(string table, Guid id, T record);
    }
}