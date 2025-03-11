using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projet_320;

namespace Projet_320_Tests
{
    [TestClass]
    public class HitboxTests
    {
        [TestMethod]
        public void IsTouched_PointInside_ReturnsTrue()
        {
            Config.ConfigJeu();
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
            Config.ConfigJeu();
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
}