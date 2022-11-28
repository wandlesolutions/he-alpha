using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HomesEngland.AHP.Shared;

public class CustomValidation : ComponentBase
{
	private ValidationMessageStore? messageStore;

	[CascadingParameter]
	private EditContext? CurrentEditContext { get; set; }

	protected override void OnInitialized()
	{
		if (CurrentEditContext is null)
		{
			throw new InvalidOperationException(
				$"{nameof(CustomValidation)} requires a cascading " +
				$"parameter of type {nameof(EditContext)}. " +
				$"For example, you can use {nameof(CustomValidation)} " +
				$"inside an {nameof(EditForm)}.");
		}

		messageStore = new(CurrentEditContext);

		CurrentEditContext.OnValidationRequested += (s, e) =>
			messageStore?.Clear();
		CurrentEditContext.OnFieldChanged += (s, e) =>
			messageStore?.Clear(e.FieldIdentifier);
	}

	public void AddErrorMessages(IDictionary<string, IEnumerable<string>> errors)
	{
		if (CurrentEditContext is not null && errors is not null)
		{
			foreach (var err in errors)
			{
				messageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
			}

			CurrentEditContext.NotifyValidationStateChanged();
		}
	}

	public void AddErrorMessage(string key, string message)
	{
		if (CurrentEditContext is not null)
		{
			messageStore?.Add(CurrentEditContext.Field(key), message);
		}
	}

	public void ClearErrors()
	{
		messageStore?.Clear();
		CurrentEditContext?.NotifyValidationStateChanged();
	}

	public void DisplayErrors(IDictionary<string, IEnumerable<string>>? errors)
	{
		ClearErrors();

		if (errors != null)
		{
			AddErrorMessages(errors);
		}
	}
}

