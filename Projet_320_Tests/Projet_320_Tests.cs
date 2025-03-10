using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Projet_320_Tests
{
    [TestClass]
    public class HitboxTests
    {
        [TestMethod]
        public void IsTouched_PointInside_ReturnsTrue()
        {
            // Arrange
            // Création d'une hitbox située à (20, 10) avec une largeur de 10 et une hauteur de 5
            Hitbox hitbox = new Hitbox(5, 10, new Position(20, 10));
            int testX = 22; // Point à l'intérieur
            int testY = 12; // Point à l'intérieur

            // Act
            bool result = hitbox.isTouched(testX, testY);

            // Assert
            Assert.IsTrue(result, "La méthode isTouched doit retourner true pour un point à l'intérieur de la hitbox");
        }

        [TestMethod]
        public void IsTouched_PointOutside_ReturnsFalse()
        {
            // Arrange
            Hitbox hitbox = new Hitbox(5, 10, new Position(20, 10));
            int testX = 35; // Point clairement à l'extérieur
            int testY = 15; // Point clairement à l'extérieur

            // Act
            bool result = hitbox.isTouched(testX, testY);

            // Assert
            Assert.IsFalse(result, "La méthode isTouched doit retourner false pour un point à l'extérieur de la hitbox");
        }
    }

    [TestClass]
    public class ProjectileTests
    {
        [TestMethod]
        public void UpdateProjectile_PositionChangesCorrectly()
        {
            // Arrange
            // On crée un projectile avec un angle de 45°, puissance 60 et position initiale (10, 10)
            Position initialPosition = new Position(10, 10);
            Projectile proj = new Projectile(45, 60, initialPosition, true, 0);
            double deltaTime = 0.1;

            // Act
            proj.UpdateProjectile(deltaTime);
            Position updatedPosition = proj.Position;

            // Assert
            // On s'attend à ce que la position soit modifiée par rapport à l'initial
            Assert.AreNotEqual(initialPosition.X, updatedPosition.X, "La position X doit être mise à jour");
            Assert.AreNotEqual(initialPosition.Y, updatedPosition.Y, "La position Y doit être mise à jour");
        }

        [TestMethod]
        public void UpdateProjectile_OutOfBounds_DeactivatesProjectile()
        {
            // Arrange
            // On crée un projectile positionné près du bord droit de la console
            // pour simuler une mise à jour qui le fait sortir des limites
            Position nearEdge = new Position(Console.WindowWidth - 5, 10);
            Projectile proj = new Projectile(0, 60, nearEdge, true, 0);
            double deltaTime = 0.5; // Temps suffisant pour que le projectile sorte

            // Act
            proj.UpdateProjectile(deltaTime);

            // Assert
            Assert.IsFalse(proj.IsActive, "Le projectile doit être désactivé s'il sort des limites de la console");
        }
    }
}
