// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace POS.MultiApp.Events
{
    public class ChangedEventArgs : EventArgs
    {
        public ChangedEventArgs(object key)
        {
            Key = key;
        }

        public object Key { get; set; }
    }
}
