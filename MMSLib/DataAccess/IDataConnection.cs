using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace MMSLib.DataAccess
{
    public interface IDataConnection
    {
        void DeleteRecord<T>(string table, ObjectId id);
        void InsertRecord<T>(string table, T record);
        T LoadRecordById<T>(string table, ObjectId id);
        List<T> LoadRecords<T>(string table);
        void UpsertRecord<T>(string table, ObjectId id, T record);
    }
}