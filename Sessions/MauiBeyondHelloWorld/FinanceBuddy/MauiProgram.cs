﻿using Microsoft.Extensions.Logging;
using FinanceBuddy.Expenses;
using FinanceBuddy.Charts;
using FinanceBuddy.Settings;
using FinanceBuddy.Categories;
using FinanceBuddy.Services;
using FinanceBuddy.Controls;
using Syncfusion.Maui.Core.Hosting;

namespace FinanceBuddy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialSymbolsOutlined");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register Services
		builder.Services.AddSingleton<ExpenseService>();

		// Register ViewModels
		builder.Services.AddTransient<ExpensesViewModel>();
		builder.Services.AddTransient<ExpenseDetailsViewModel>();
		builder.Services.AddTransient<AddExpenseViewModel>();
		builder.Services.AddTransient<ChartsViewModel>();
		builder.Services.AddTransient<SettingsViewModel>();
		builder.Services.AddTransient<CategoriesViewModel>();

		// Register Pages
		builder.Services.AddTransient<ExpensesPage>();
		builder.Services.AddTransient<ExpenseDetailsPage>();
		builder.Services.AddTransient<AddExpensePage>();
		builder.Services.AddTransient<ChartsPage>();
		builder.Services.AddTransient<SettingsPage>();
		builder.Services.AddTransient<CategoriesPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
