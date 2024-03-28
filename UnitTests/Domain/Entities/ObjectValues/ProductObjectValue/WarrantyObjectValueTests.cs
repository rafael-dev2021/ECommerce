﻿using Domain.Entities.ObjectValues.ProductObjectValue;
using FluentValidation.TestHelper;
using FluentValidations.Domain.Entities.ObjectValues.ProductObjectValue;
using Xunit;

namespace UnitTests.Domain.Entities.ObjectValues.ProductObjectValue;

/// <summary>
/// Unit tests for the <see cref="WarrantyObjectValue"/> class.
/// </summary>
public class WarrantyObjectValueTests
{
    /// <summary>
    /// The validator for the <see cref="WarrantyObjectValue"/> class.
    /// </summary>
    private readonly WarrantyObjectValueValidator _validator = new();

    /// <summary>
    /// Tests that the validator does not have any errors when the warranty length is valid.
    /// </summary>
    [Fact]
    public void Should_Not_Have_Error_When_WarrantyLength_Is_Valid()
    {
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();
        warrantyObjectValue.SetWarrantyLength("1 year"); 
        warrantyObjectValue.SetWarrantyInformation("Limited warranty");

        // Act
        var result = _validator.TestValidate(warrantyObjectValue);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.WarrantyLength);
    }

    /// <summary>
    /// Tests that the validator does not have any errors when the warranty information is valid.
    /// </summary>
    [Fact]
    public void Should_Not_Have_Error_When_WarrantyInformation_Is_Valid()
    {
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();
        warrantyObjectValue.SetWarrantyLength("1 year"); 
        warrantyObjectValue.SetWarrantyInformation("Limited warranty");

        // Act
        var result = _validator.TestValidate(warrantyObjectValue);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.WarrantyInformation);
    }

    /// <summary>
    /// Tests that the validator has an error when the warranty length is empty.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_WarrantyLength_Is_Empty()
    {
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();
        warrantyObjectValue.SetWarrantyLength(""); 
        warrantyObjectValue.SetWarrantyInformation("Limited warranty");

        // Act
        var result = _validator.TestValidate(warrantyObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.WarrantyLength)
            .WithErrorMessage("Warranty length cannot be empty.");
    }

    /// <summary>
    /// Tests that the validator has an error when the warranty information is empty.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_WarrantyInformation_Is_Empty()
    {
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();
        warrantyObjectValue.SetWarrantyLength("1 year"); 
        warrantyObjectValue.SetWarrantyInformation("");
        // Act
        var result = _validator.TestValidate(warrantyObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.WarrantyInformation)
            .WithErrorMessage("Warranty information cannot be empty.");
    }

    /// <summary>
    /// Tests that the validator has an error when the warranty length exceeds the maximum length.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_WarrantyLength_Exceeds_Maximum_Length()
    {
        var stringTest = new string('x', 31);
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();
        warrantyObjectValue.SetWarrantyLength(stringTest); 
        warrantyObjectValue.SetWarrantyInformation("Limited warranty");
        // Act
        var result = _validator.TestValidate(warrantyObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.WarrantyLength)
            .WithErrorMessage("Warranty length must have a maximum length of 30 characters.");
    }

    /// <summary>
    /// Tests that the validator has an error when the warranty information exceeds the maximum length.
    /// </summary>
    [Fact]
    public void Should_Have_Error_When_WarrantyInformation_Exceeds_Maximum_Length()
    {
        // Arrange
        var stringTest = new string('x', 51);
        // Arrange
        var warrantyObjectValue = new WarrantyObjectValue();
        warrantyObjectValue.SetWarrantyLength("1 year"); 
        warrantyObjectValue.SetWarrantyInformation(stringTest);
        // Act
        var result = _validator.TestValidate(warrantyObjectValue);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.WarrantyInformation)
            .WithErrorMessage("Warranty information must have a maximum length of 50 characters.");
    }
}