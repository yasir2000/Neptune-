﻿//
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
// Implementation: Simon Chamberland
// Project Manager: Froduald Kabanza
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDDLParser
{
  /// <summary>
  /// This attribute merely indicates that the given element is not present in a regular
  /// PDDL problem and has rather been added for TLPlan.
  /// </summary>
  public class TLPlanAttribute : Attribute
  {
  }
}
