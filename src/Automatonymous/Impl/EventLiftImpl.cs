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
namespace Automatonymous.Impl
{
    using Taskell;


    public class EventLiftImpl<TInstance> :
        EventLift<TInstance>
        where TInstance : class
    {
        readonly Event _event;
        readonly StateMachine<TInstance> _stateMachine;

        public EventLiftImpl(StateMachine<TInstance> stateMachine, Event @event)
        {
            _stateMachine = stateMachine;
            _event = @event;
        }

        void EventLift<TInstance>.Raise(Composer composer, TInstance instance)
        {
            _stateMachine.RaiseEvent(composer, instance, _event);
        }
    }


    public class EventLiftImpl<TInstance, TData> :
        EventLift<TInstance, TData>
        where TInstance : class
    {
        readonly Event<TData> _event;
        readonly StateMachine<TInstance> _stateMachine;

        public EventLiftImpl(StateMachine<TInstance> stateMachine, Event<TData> @event)
        {
            _stateMachine = stateMachine;
            _event = @event;
        }

        void EventLift<TInstance, TData>.Raise(Composer composer, TInstance instance, TData data)
        {
            _stateMachine.RaiseEvent(composer, instance, _event, data);
        }
    }
}