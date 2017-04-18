using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionContainer
{
    public struct Try<TFailure, TSuccess>
    {
        internal TFailure Failure { get; }
        internal TSuccess Success { get; }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        internal Try(TFailure failure)
        {
            IsFailure = true;
            Failure = failure;
            Success = default(TSuccess);
        }

        internal Try(TSuccess success)
        {
            IsFailure = false;
            Failure = default(TFailure);
            Success = success;
        }

        public static implicit operator Try<TFailure, TSuccess>(TFailure failure) => new Try<TFailure, TSuccess>(failure);
        public static implicit operator Try<TFailure, TSuccess>(TSuccess success) => new Try<TFailure, TSuccess>(success);

        public TResult Match<TResult>(Func<TFailure, TResult> failure, Func<TSuccess, TResult> success)
        {
            return IsFailure ? failure(Failure) : success(Success);
        }

        public Unit Match(Action<TFailure> failure, Action<TSuccess> success)
        {
            return Match(Helpers.ToFunc(failure), Helpers.ToFunc(success));
        }
    }

    public struct Unit { }

    public static partial class Helpers
    {
        private static readonly Unit unit = new Unit();
        public static Unit Unit()
        {
            return unit;
        }

        public static Func<T, Unit> ToFunc<T>(Action<T> action)
        {
            return (o) =>
            {
                action(o);
                return Unit();
            };
        }
    }
}
