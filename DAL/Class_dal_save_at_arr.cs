using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DAL
{
    class Class_dal_save_at_arr : IDAL
    {
        int[] values;
        const int CAPACITY = 4;
        int count = 0;

        public Class_dal_save_at_arr()
        {
            values = new int[CAPACITY];
        }

        public void InsertValue(int item)
        {
            if (count >= CAPACITY)
                throw new OverloadCapacityException(CAPACITY,"DAL Exception: out of place ");

            values[count++] = item;
        }
    }

    // Desiging Custom exceptions (per Microsoft .NET 4 documemntaion)
    // - Avoid deep exceptions hierarchies
    // - Derive exceptions from System.Exception or other common base exceptions
    // - End exception class names with the Exception suffix
    // - Make exceptions serializable
    // - Provide at least following four common constructors on all exceptions, make sure that the names and types of
    //   parameters are the same as of those used in our code example
    // - Security sensitive information: provide in ToString only after demanding an appropriate permission, store it
    //   in private exception state, ensure that only trusted code can get the information
    // - Consider providing exception properties for programmatic access to extra information (besides the message string)
    //   relevant to the exception
    public class OverloadCapacityException : Exception, ISerializable
    {
        public int capacity { get; private set; }

        public OverloadCapacityException() : base() { }
        public OverloadCapacityException(string message) : base(message) { }
        public OverloadCapacityException(string message, Exception inner) : base(message, inner) { }
        protected OverloadCapacityException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        // special constructor for our custom exception
        public OverloadCapacityException(int capacity, string message)
            : base(message)
        {
            this.capacity = capacity;
        }

        override public string ToString()
        {
            return "OverloadCapacityException: DAL capacity of " + capacity + " overloaded\n" + Message;
        }
    
    
    }
}
