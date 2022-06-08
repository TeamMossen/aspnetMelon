using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Models.Parameters.Interfaces;

public interface IExtensionBinder<TSelf> where TSelf : IExtensionBinder<TSelf>
{
    /// <summary>
    /// The method discovered by RequestDelegateFactory on types used as parameters of route
    /// handler delegates to support custom binding.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/>.</param>
    /// <param name="parameter">The <see cref="ParameterInfo"/> for the parameter being bound to.</param>
    /// <returns>The value to assign to the parameter.</returns>
    static abstract ValueTask<TSelf?> BindAsync(HttpContext context, ParameterInfo parameter);
}