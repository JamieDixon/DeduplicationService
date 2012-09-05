// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeduplicationService.cs" company="Jamie Dixon">
//   Jamie Dixon
// </copyright>
// <summary>
//   Defines the DeduplicationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DeduplicationService
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The deduplication service.
    /// </summary>
    public interface IDeduplicationService
    {
        /// <summary>
        /// The deduplicate.
        /// </summary>
        /// <param name="operand">
        /// The operand.
        /// </param>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <param name="operators">
        /// The operators.
        /// </param>
        /// <typeparam name="TResult">
        /// The result type.
        /// </typeparam>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; TResult].
        /// </returns>
        IEnumerable<TResult> Deduplicate<TResult>(IEnumerable<TResult> operand, IEqualityComparer<TResult> comparer, params IEnumerable<TResult>[] operators);

        /// <summary>
        /// The deduplicate.
        /// </summary>
        /// <param name="operand">
        /// The operand.
        /// </param>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <param name="operators">
        /// The operators.
        /// </param>
        /// <typeparam name="TResult">
        /// The result type.
        /// </typeparam>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; TResult].
        /// </returns>
        IEnumerable<TResult> Deduplicate<TResult>(IEnumerable<TResult> operand, Func<TResult, TResult, bool> func, params IEnumerable<TResult>[] operators);

        /// <summary>
        /// The deduplicate.
        /// </summary>
        /// <param name="operand">
        /// The operand.
        /// </param>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <param name="operators">
        /// The operators.
        /// </param>
        /// <typeparam name="TResult">
        /// The result type.
        /// </typeparam>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; TResult].
        /// </returns>
        IEnumerable<TResult> Deduplicate<TResult>(IEnumerable<TResult> operand, Func<TResult, dynamic> func, params IEnumerable<TResult>[] operators);

        /// <summary>
        /// The deduplicate.
        /// </summary>
        /// <param name="operand">
        /// The operand.
        /// </param>
        /// <param name="operators">
        /// The operators.
        /// </param>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; ComplexType].
        /// </returns>
        IEnumerable<ComplexType> Deduplicate(IEnumerable<ComplexType> operand, params IEnumerable<ComplexType>[] operators);
    }
}
