﻿using System;
using System.Runtime.InteropServices;
using FRESharpCore;

namespace FreSharp {
    /// <summary>
    /// FreByteArraySharp wraps a C FREByteArray with helper methods.
    /// </summary>
    public class FreByteArraySharp {
        /// <summary>
        /// The number of bytes in the bytes array.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// The Byte Array 
        /// </summary>
        public byte[] Bytes { get; set; }

        private readonly IntPtr _freByteArray = IntPtr.Zero;
        private readonly FREByteArrayCLR _byteArray = new FREByteArrayCLR();
        /// <summary>
        /// Creates an empty C# FREByteArray
        /// </summary>
        public FreByteArraySharp() { }

        /// <summary>
        /// Creates a C# FREByteArray from a C FREByteArray
        /// </summary>
        /// <param name="freByteArray"></param>
        public FreByteArraySharp(IntPtr freByteArray) {
            _freByteArray = freByteArray;
        }

        /// <summary>
        /// Calls FREAcquireByteArray on the C FREByteArray
        /// </summary>
        public void Acquire() {
            FreSharpHelper.Core.acquireByteArrayData(_freByteArray, _byteArray);
            Length = (int)_byteArray.length;
            Bytes = new byte[Length];
            Marshal.Copy(_byteArray.bytes, Bytes, 0, Length);
        }

        /// <summary>
        /// Calls FREReleaseByteArray on the C FREByteArray
        /// </summary>
        public void Release() {
            FreSharpHelper.Core.releaseByteArrayData(_freByteArray);
        }

        /// <summary>
        /// Returns the associated C FREByteArray of the C# FREByteArray.
        /// </summary>
        /// <returns></returns>
        public IntPtr Get() {
            return _freByteArray;
        }

    }
}