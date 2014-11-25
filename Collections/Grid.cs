using System.Collections;
using System;
using System.Runtime.Serialization;

namespace RoomOfRequirement.Generic
{
    /// <summary>
    /// This class represents a set of data shaped as a 2D grid. 
    /// </summary>
    [Serializable]
    public class Grid<T> : IEnumerable, ISerializable
    {
        /// <summary>
        /// The internal data.
        /// </summary>
        private readonly T[] internalData;

        /// <summary>
        /// Gets the width.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="Grid`1"/> with the specified x y.
        /// </summary>
        public T this[int x, int y]
        {
            get
            {
                return internalData[GetArrayIndex(x, y)];
            }

            set
            {
                internalData[GetArrayIndex(x, y)] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid`1"/> class.
        /// </summary>
        public Grid(int height, int width)
        {
            Width = width;
            Height = height;
            internalData = new T[Width * Height];
        }

        /// <summary>
        /// Converts a pair of matrix indexes [i,j] in the corresponding
        /// index of the linearized array associated to the map matrix.
        /// </summary>
        private int GetArrayIndex(int x, int y)
        {
            return y * Width + x;
        }

        public bool IsOutOfBound(int x, int y)
        {
            return x < 0 || y < 0 || x >= Width || y >= Height;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator GetEnumerator()
        {
            return internalData.GetEnumerator();
        }

        #region ISerializableImplementation
        /// <summary>
        /// Initializes a new instance of the <see cref="Grid`1"/> class.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Context.</param>
        protected Grid(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            Width = (int)info.GetValue("Width", typeof(int));
            Height = (int)info.GetValue("Height", typeof(int));
            internalData = (T[])info.GetValue("InternalData", typeof(T[]));
        }

        /// <summary>
        /// Implement ISerializable interface.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Streaming Context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
            info.AddValue("InternalData", internalData);
        }
        #endregion
    }
}
