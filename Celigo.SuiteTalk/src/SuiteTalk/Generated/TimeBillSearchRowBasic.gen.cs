//~ Generated by SearchStubs/SearchRowBasic

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    partial class TimeBillSearchRowBasic
    {
        // TODO: Make this Lazy and Weak referenced so that it can be garbaged collected
        private static readonly Lazy<ColumnFactory> columnFactoryLoader = new Lazy<ColumnFactory>(() => new ColumnFactory());

        public override void SetColumns(string[] columnNames)
        {
            var factory = columnFactoryLoader.Value;
            for (int i = 0; i < columnNames.Length; i++)
            {
                factory.BuildColumn(this, columnNames[i]);
            }
        }

        class ColumnFactory:  ColumnFactory<TimeBillSearchRowBasic>
        {
            protected override Dictionary<string, Action<TimeBillSearchRowBasic>> InitializeColumnBuilders()
            {
                return new Dictionary<string, Action<TimeBillSearchRowBasic>> {
                    { "approvalStatus", r => r.@approvalStatus = new [] { new SearchColumnSelectField { customLabel = "approvalStatus" } } },
                    { "break", r => r.@break = new [] { new SearchColumnStringField { customLabel = "break" } } },
                    { "class", r => r.@class = new [] { new SearchColumnSelectField { customLabel = "class" } } },
                    { "customer", r => r.@customer = new [] { new SearchColumnSelectField { customLabel = "customer" } } },
                    { "date", r => r.@date = new [] { new SearchColumnDateField { customLabel = "date" } } },
                    { "dateCreated", r => r.@dateCreated = new [] { new SearchColumnDateField { customLabel = "dateCreated" } } },
                    { "department", r => r.@department = new [] { new SearchColumnSelectField { customLabel = "department" } } },
                    { "durationDecimal", r => r.@durationDecimal = new [] { new SearchColumnDoubleField { customLabel = "durationDecimal" } } },
                    { "employee", r => r.@employee = new [] { new SearchColumnSelectField { customLabel = "employee" } } },
                    { "endTime", r => r.@endTime = new [] { new SearchColumnDateField { customLabel = "endTime" } } },
                    { "externalId", r => r.@externalId = new [] { new SearchColumnSelectField { customLabel = "externalId" } } },
                    { "hours", r => r.@hours = new [] { new SearchColumnStringField { customLabel = "hours" } } },
                    { "internalId", r => r.@internalId = new [] { new SearchColumnSelectField { customLabel = "internalId" } } },
                    { "isBillable", r => r.@isBillable = new [] { new SearchColumnBooleanField { customLabel = "isBillable" } } },
                    { "isExempt", r => r.@isExempt = new [] { new SearchColumnBooleanField { customLabel = "isExempt" } } },
                    { "isProductive", r => r.@isProductive = new [] { new SearchColumnBooleanField { customLabel = "isProductive" } } },
                    { "isUtilized", r => r.@isUtilized = new [] { new SearchColumnBooleanField { customLabel = "isUtilized" } } },
                    { "item", r => r.@item = new [] { new SearchColumnStringField { customLabel = "item" } } },
                    { "lastModified", r => r.@lastModified = new [] { new SearchColumnDateField { customLabel = "lastModified" } } },
                    { "location", r => r.@location = new [] { new SearchColumnSelectField { customLabel = "location" } } },
                    { "memo", r => r.@memo = new [] { new SearchColumnStringField { customLabel = "memo" } } },
                    { "paidExternally", r => r.@paidExternally = new [] { new SearchColumnBooleanField { customLabel = "paidExternally" } } },
                    { "payItem", r => r.@payItem = new [] { new SearchColumnSelectField { customLabel = "payItem" } } },
                    { "payrollDate", r => r.@payrollDate = new [] { new SearchColumnDateField { customLabel = "payrollDate" } } },
                    { "rate", r => r.@rate = new [] { new SearchColumnDoubleField { customLabel = "rate" } } },
                    { "rejectionNote", r => r.@rejectionNote = new [] { new SearchColumnStringField { customLabel = "rejectionNote" } } },
                    { "startTime", r => r.@startTime = new [] { new SearchColumnDateField { customLabel = "startTime" } } },
                    { "status", r => r.@status = new [] { new SearchColumnStringField { customLabel = "status" } } },
                    { "subsidiary", r => r.@subsidiary = new [] { new SearchColumnStringField { customLabel = "subsidiary" } } },
                    { "supervisorApproval", r => r.@supervisorApproval = new [] { new SearchColumnBooleanField { customLabel = "supervisorApproval" } } },
                    { "temporaryLocalJurisdiction", r => r.@temporaryLocalJurisdiction = new [] { new SearchColumnStringField { customLabel = "temporaryLocalJurisdiction" } } },
                    { "temporaryStateJurisdiction", r => r.@temporaryStateJurisdiction = new [] { new SearchColumnStringField { customLabel = "temporaryStateJurisdiction" } } },
                    { "timeModified", r => r.@timeModified = new [] { new SearchColumnBooleanField { customLabel = "timeModified" } } },
                    { "timeSheet", r => r.@timeSheet = new [] { new SearchColumnSelectField { customLabel = "timeSheet" } } },
                    { "type", r => r.@type = new [] { new SearchColumnEnumSelectField { customLabel = "type" } } },
                };
            }
        }
    }
}