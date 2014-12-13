// Copyright 2011-2013 Chris Patterson, Dru Sellers
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Automatonymous
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public static class IntrospectionExtensions
    {
        public static Task<IEnumerable<Event>> NextEvents<TInstance>(this StateMachine<TInstance> machine, TInstance instance)
            where TInstance : class
        {
            if (machine == null)
                throw new ArgumentNullException("machine");
            if (instance == null)
                throw new ArgumentNullException("instance");

            return machine.NextEvents(await machine.InstanceStateAccessor.Get(instance));
        }
    }
}