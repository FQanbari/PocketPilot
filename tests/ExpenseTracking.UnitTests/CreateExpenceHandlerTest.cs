using ExpenseTracking.Application.Model;
using ExpenseTracking.Application.Queries.Expense;
using ExpenseTracking.Application.Services;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.Repositories;
using ExpenseTracking.Infrastructure.Repositories;
using MediatR;
using Moq;
using Shouldly;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ExpenseTracking.UnitTests;

public class CreateExpenceHandlerTest
{
    private readonly ExpenseTracker _expenseTracker;
    private readonly Mock<IBudgetService> _budgetServiceMock;
    private readonly Mock<IBudgetRepository> _budgetRepository;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IGenericRepository<Expense>> _expenseRepositoryMock;
    private readonly Mock<IMediator> _meiatorMock;
    private readonly CreateExpenseQueryHandler _handler;
    private readonly CreateExpenseQuery _request;
    private readonly Budget _budget;

    public CreateExpenceHandlerTest()
    {
        _expenseTracker = new ExpenseTracker();
        _budgetServiceMock = new Mock<IBudgetService>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _expenseRepositoryMock = new Mock<IGenericRepository<Expense>>();
        _budgetRepository = new Mock<IBudgetRepository>();
        _handler = new CreateExpenseQueryHandler(_unitOfWorkMock.Object);
        _meiatorMock = new Mock<IMediator>();
        _request = new CreateExpenseQuery
        {
            Amount = 100.0m,
            Category = "Groceries",
            Date = DateTime.Now,
            Notes = "Shopping"
        };
        _budget = new Budget
        {
            UserId = 1,
            Category = "Groceries",
            AllocatedAmount = 200.0m
        };
    }


    [Fact]
    public async Task Handle_ValidExpense_AddsExpenseAndUpdatesBudget()
    {
        // Arrange
        _budgetServiceMock.Setup(x => x.GetBudgetByCategoryAsync(_request.UserId, _request.Category))
            .ReturnsAsync(_budget);

        // Act
        Expense savedExpense = null;
        await _handler.Handle(_request, CancellationToken.None);

        // Assert
        _expenseRepositoryMock.Verify(x => x.Create(It.IsAny<Expense>(), CancellationToken.None), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        //budgetServiceMock.Verify(x => x.NotifyBudgetExceededAsync(request.UserId, budget), Times.Never);

        //Assert.Equal(_request.Amount, _expenseTracker.Expenses?.Last().Amount.Amount);
        Assert.Equal(_request.Category, _expenseTracker.Expenses?.Last().Category);
        Assert.Equal(_request.Date, _expenseTracker.Expenses?.Last().Date);
        Assert.Equal(_request.Notes, _expenseTracker.Expenses?.Last().Notes);
        Assert.Equal(_request.Id.Value, _expenseTracker.Expenses?.Last().Id);
    }

    [Fact]
    public async Task Handle_ExpenseExceedsBudget_SendsNotification()
    {
        // Arrange
        _unitOfWorkMock.Setup(x => x.GetRepository<IBudgetRepository, Budget>())
            .Returns(_budgetRepository.Object);
        _budgetRepository.Setup(x => x.GetBudgetByCategoryAsync(_request.UserId, _request.Category))
            .ReturnsAsync(_budget);

        // Act
        await _handler.Handle(_request, CancellationToken.None);

        // Assert
        _expenseRepositoryMock.Verify(x => x.Create(It.IsAny<Expense>(), CancellationToken.None), Times.Once);
        _unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        //budgetServiceMock.Verify(x => x.NotifyBudgetExceededAsync(request.UserId, budget), Times.Once);

        //Assert.Equal(_request.Amount, _expenseTracker.Expenses?.Last().Amount.Amount);
        Assert.Equal(_request.Category, _expenseTracker.Expenses?.Last().Category);
        Assert.Equal(_request.Date, _expenseTracker.Expenses?.Last().Date);
        Assert.Equal(_request.Notes, _expenseTracker.Expenses?.Last().Notes);
        Assert.Equal(_request.Id.Value, _expenseTracker.Expenses?.Last().Id);
    }

    [Fact]
    public async Task Handle_NullRequest_ThrowsArgumentNullException()
    {
        // Arrange
        var expenseTrackerMock = new Mock<ExpenseTracker>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var budgetServiceMock = new Mock<IBudgetService>();

        var handler = new CreateExpenseQueryHandler(
            //expenseTrackerMock.Object,
            unitOfWorkMock.Object
        );

        // Act & Assert        
        await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null, CancellationToken.None));

    }
}
