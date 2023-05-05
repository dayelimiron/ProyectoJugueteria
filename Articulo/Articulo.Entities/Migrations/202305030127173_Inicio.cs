namespace Articulo.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Apellido = c.String(nullable: false, maxLength: 80),
                        Direccion = c.String(nullable: false, maxLength: 80),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        DUi = c.String(nullable: false, maxLength: 30),
                        CargoId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Cargoes", t => t.CargoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.CargoId)
                .Index(t => t.EstadoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 40),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 30),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoriaId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        DetalleVenta_DetalleVentaId = c.Int(),
                        DetalleCompras_DetalleCompraId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.DetalleVentas", t => t.DetalleVenta_DetalleVentaId)
                .ForeignKey("dbo.DetalleCompras", t => t.DetalleCompras_DetalleCompraId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.CategoriaId)
                .Index(t => t.EstadoId)
                .Index(t => t.DetalleVenta_DetalleVentaId)
                .Index(t => t.DetalleCompras_DetalleCompraId);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        DetalleCompraId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(nullable: false),
                        CompraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleCompraId)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .Index(t => t.CompraId);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraId = c.Int(nullable: false, identity: true),
                        FechaCompra = c.DateTime(nullable: false),
                        TotalCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProveedorId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraId)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.ProveedorId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 80),
                        Password = c.String(nullable: false, maxLength: 80),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        FechaVenta = c.DateTime(nullable: false),
                        TotalVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.DetalleVentas",
                c => new
                    {
                        DetalleVentaId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductoId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleVentaId)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.Inventarios",
                c => new
                    {
                        InventarioId = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventarioId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Tabla = c.String(nullable: false, maxLength: 50),
                        Accion = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        Usuario = c.String(nullable: false),
                        Usuarios_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_UsuarioId)
                .Index(t => t.Usuarios_UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "Usuarios_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Empleadoes", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Inventarios", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.Productoes", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Productoes", "DetalleCompras_DetalleCompraId", "dbo.DetalleCompras");
            DropForeignKey("dbo.Ventas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.DetalleVentas", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Productoes", "DetalleVenta_DetalleVentaId", "dbo.DetalleVentas");
            DropForeignKey("dbo.Ventas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Usuarios", "RolId", "dbo.Rols");
            DropForeignKey("dbo.Rols", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Empleadoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Compras", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Proveedors", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Compras", "ProveedorId", "dbo.Proveedors");
            DropForeignKey("dbo.DetalleCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.Productoes", "CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Categorias", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Cargoes", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Empleadoes", "CargoId", "dbo.Cargoes");
            DropIndex("dbo.Logs", new[] { "Usuarios_UsuarioId" });
            DropIndex("dbo.Inventarios", new[] { "ProductoId" });
            DropIndex("dbo.DetalleVentas", new[] { "VentaId" });
            DropIndex("dbo.Clientes", new[] { "EstadoId" });
            DropIndex("dbo.Ventas", new[] { "UsuarioId" });
            DropIndex("dbo.Ventas", new[] { "ClienteId" });
            DropIndex("dbo.Rols", new[] { "EstadoId" });
            DropIndex("dbo.Usuarios", new[] { "RolId" });
            DropIndex("dbo.Proveedors", new[] { "EstadoId" });
            DropIndex("dbo.Compras", new[] { "UsuarioId" });
            DropIndex("dbo.Compras", new[] { "ProveedorId" });
            DropIndex("dbo.DetalleCompras", new[] { "CompraId" });
            DropIndex("dbo.Productoes", new[] { "DetalleCompras_DetalleCompraId" });
            DropIndex("dbo.Productoes", new[] { "DetalleVenta_DetalleVentaId" });
            DropIndex("dbo.Productoes", new[] { "EstadoId" });
            DropIndex("dbo.Productoes", new[] { "CategoriaId" });
            DropIndex("dbo.Categorias", new[] { "EstadoId" });
            DropIndex("dbo.Empleadoes", new[] { "UsuarioId" });
            DropIndex("dbo.Empleadoes", new[] { "EstadoId" });
            DropIndex("dbo.Empleadoes", new[] { "CargoId" });
            DropIndex("dbo.Cargoes", new[] { "EstadoId" });
            DropTable("dbo.Logs");
            DropTable("dbo.Inventarios");
            DropTable("dbo.DetalleVentas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Ventas");
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Compras");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Cargoes");
        }
    }
}
