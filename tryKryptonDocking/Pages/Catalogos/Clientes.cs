﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryKryptonDocking.Pages.Catalogos
{
    public partial class Clientes : Base.CatalogBase<libProduccionDataBase.Tablas.Cliente>
    {
        public Clientes()
        {
            InitializeComponent();
        }

    }
}