[Flags]
		public enum statusProcesoProduccion
		{
			PorProgramar = 1 << 0,
			Programada = 1 << 1,
			Reprogramada = 1 << 2,
			EnProceso = 1 << 3,
			Concluida = 1 << 4,
			Activa = 1 << 5
		}
