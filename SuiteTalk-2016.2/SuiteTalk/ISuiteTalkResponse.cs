using System;
using System.Collections.Generic;
using System.Text;

namespace SuiteTalk
{
#pragma warning disable IDE1006 // Naming Styles
    public interface ISuiteTalkResponse
    { 
        Status status { get; set; }
    }

    public interface IWriteResponse
    {
        WriteResponse writeResponse { get; set; }
    }

    public interface IReadResponse
    {
        ReadResponse readResponse { get; set; }
    }

#pragma warning restore IDE1006 // Naming Styles

    public partial class WriteResponse: ISuiteTalkResponse {}
    public partial class ReadResponse: ISuiteTalkResponse {}
}
