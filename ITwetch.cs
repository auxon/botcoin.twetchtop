using System;
using System.Collections.Generic;
using System.Reactive;
using System.Linq;

namespace Botcoin.TwetchTop.ITwetch {
    public interface ITwetch<TwetchType> {
        IObservable<ITwetchMeme> GetMemes(this twetchNode, Func<IObservable<ITwetchMeme>, 
    }
}