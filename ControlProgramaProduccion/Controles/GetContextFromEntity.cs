﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlProgramaProduccion.Controles
{
	public static class GetContextFromEntity
	{
		public static DbContext GetDbContextFromEntity ( object entity )
		{
			var object_context = GetObjectContextFromEntity ( entity );

			if ( object_context == null || object_context.TransactionHandler == null )
				return null;

			return object_context.TransactionHandler.DbContext;
		}

		private static ObjectContext GetObjectContextFromEntity ( object entity )
		{
			var field = entity.GetType ( ).GetField ( "_entityWrapper" );

			if ( field == null )
				return null;

			var wrapper = field.GetValue ( entity );
			var property = wrapper.GetType ( ).GetProperty ( "Context" );
			var context = (ObjectContext)property.GetValue ( wrapper, null );

			return context;
		}
	}
}
