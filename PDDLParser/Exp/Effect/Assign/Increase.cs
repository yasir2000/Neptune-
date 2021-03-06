//
// Copyright (c) 2009 Froduald Kabanza and the Université de Sherbrooke.
// Use of this software is permitted for non-commercial research purposes, and
// it may be copied or applied only for that use. All copies must include this
// copyright message.
// 
// This is a research prototype and it has not gone through intensive tests and
// is delivered as is. It may still contain bugs. Froduald Kabanza and the
// Université de Sherbrooke disclaim any responsibility for damage that may be
// caused by using it.
//
// Please note that this file was inspired in part by the PDDL4J library:
// http://www.math-info.univ-paris5.fr/~pellier/software/software.php 
//
// Implementation: Simon Chamberland
// Project Manager: Froduald Kabanza
//

using System.Collections.Generic;
using PDDLParser.Exception;
using PDDLParser.Exp.Formula;
using PDDLParser.Exp.Struct;
using PDDLParser.World;

namespace PDDLParser.Exp.Effect.Assign
{
  /// <summary>
  /// This class represents a fluent increase operation.
  /// </summary>
  public class Increase : NumericAssignEffect
  {
    /// <summary>
    /// Creates a new fluent increase operation.
    /// </summary>
    /// <param name="head">The numeric fluent whose value is to be decreased.</param>
    /// <param name="body">The numeric value to decrease the fluent by.</param>
    public Increase(NumericFluentApplication head, INumericExp body)
      : base("increase", head, body)
    {
      System.Diagnostics.Debug.Assert(head != null && body != null);
    }

    /// <summary>
    /// Updates the world with this fluent assignment.
    /// </summary>
    /// <param name="head">The evaluated fluent application to update.</param>
    /// <param name="updateWorld">The world to update.</param>
    /// <param name="bindings">A set of variable bindings.</param>
    protected override void UpdateWorldWithAssignEffect(FluentApplication head, IDurativeOpenWorld updateWorld,
                                                        LocalBindings bindings)
    {
      FuzzyDouble headValue = ((NumericFluentApplication)head).Evaluate(updateWorld, bindings);
      FuzzyDouble bodyValue = Body.Evaluate(updateWorld, bindings);

      if (headValue.Status != FuzzyDouble.State.Defined)
      {
        throw new UndefinedExpException(this.ToString() +
          " failed since the first operand evaluates to undefined or unknown.");
      }
      else if (bodyValue.Status != FuzzyDouble.State.Defined)
      {
        throw new UndefinedExpException(this.ToString() +
          " failed since the second operand evaluates to undefined or unknown.");
      }
      else
      {
        updateWorld.SetNumericFluent((NumericFluentApplication)head, headValue.Value + bodyValue.Value);
      }
    }
  }
}