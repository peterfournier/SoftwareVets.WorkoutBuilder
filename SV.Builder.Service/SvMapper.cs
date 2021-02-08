using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SV.Builder.Service
{
    public class SvMapper : GraniteCore.IGraniteMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TDestination> Map<TSource, TDestination>(IQueryable<TSource> source)
        {
            throw new NotImplementedException();
        }
    }
}
