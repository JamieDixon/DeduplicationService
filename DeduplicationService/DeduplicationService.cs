// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeduplicationService.cs" company="Jamie Dixon">
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
    using System.Linq;

    /// <summary>
    /// The deduplication service.
    /// </summary>
    public class DeduplicationService : IDeduplicationService
    {
        /// <summary>
        /// The deduplicate.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type we're dealing with.
        /// </typeparam>
        /// <param name="operand">
        /// The item being deduplicated.
        /// </param>
        /// <param name="func">
        /// The func.
        /// </param>
        /// <param name="operators">
        /// The operators.
        /// </param>
        /// <returns>
        /// The TResult.
        /// </returns>
        public IEnumerable<TResult> Deduplicate<TResult>(IEnumerable<TResult> operand, Func<TResult, TResult, bool> func, params IEnumerable<TResult>[] operators)
        {
            var comparer = new Comparer<TResult>(func);
            return this.Deduplicate(operand, comparer, operators);
        }

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
        /// The type we're dealing with.
        /// </typeparam>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; TResult].
        /// </returns>
        public IEnumerable<TResult> Deduplicate<TResult>(IEnumerable<TResult> operand, Func<TResult, dynamic> func, params IEnumerable<TResult>[] operators)
        {
            Func<TResult, TResult, bool> f = (x, y) => func(x) == func(y);
            return this.Deduplicate(operand, f, operators);
        }

        /// <summary>
        /// The deduplicate using default equaliy comparer based on Id.
        /// </summary>
        /// <param name="operand">
        /// The operand.
        /// </param>
        /// <param name="operators">
        /// The operators.
        /// </param>
        /// <returns>
        /// An IEnumerable`1[T -&gt; ComplexType].
        /// </returns>
        public IEnumerable<ComplexType> Deduplicate(IEnumerable<ComplexType> operand, params IEnumerable<ComplexType>[] operators)
        {
            return this.Deduplicate(operand, x => x.Id, operators);
        }

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
        /// The type we're dealing with.
        /// </typeparam>
        /// <returns>
        /// The System.Collections.Generic.IEnumerable`1[T -&gt; TResult].
        /// </returns>
        public IEnumerable<TResult> Deduplicate<TResult>(IEnumerable<TResult> operand, IEqualityComparer<TResult> comparer, params IEnumerable<TResult>[] operators)
        {
            // Flatten the operator collections into one collection.
            var operatorItems = operators.SelectMany(x => x);
            return operand.Except(operatorItems, comparer);
        }
    }
}