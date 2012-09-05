// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Comparer.cs" company="">
//   
// </copyright>
// <summary>
//   The comparer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DeduplicationService
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The comparer.
    /// </summary>
    /// <typeparam name="T">
    /// The type for the comparison.
    /// </typeparam>
    public class Comparer<T> : IEqualityComparer<T>
    {
        #region Constants and Fields

        /// <summary>
        /// The comparer.
        /// </summary>
        private readonly Func<T, T, bool> comparer;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Comparer{T}"/> class.
        /// </summary>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        public Comparer(Func<T, T, bool> comparer)
        {
            this.comparer = comparer;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool Equals(T x, T y)
        {
            return this.comparer(x, y);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The System.Int32.
        /// </returns>
        public int GetHashCode(T obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }

        #endregion
    }
}