// ----------------------------------------------------------------
// Copyright 	©2023 Charke All Rights Reserved.
// FileName: 	IHello
// Guid:	 	4e37e82f-50a3-41c5-8511-2b6774c3f280
// Author:	 	charke
// Email:	 	charke_cc@163.com
// CreateTime:	2023/5/24 22:44:54
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainInterfaces;

public interface IHello : IGrainWithIntegerKey
{
    ValueTask<string> SayHello(string greeting);
}
