using System;
using System.IO;

namespace Action_Logger
{
    public class ActionLogger
    {
		string[] Actions = null;

		public bool ShowDate { get; set; }

		/// <summary>
		/// Creates a new instance of <see cref="ActionLogger"/>.
		/// </summary>
		public ActionLogger()
		{
			ShowDate = false;
		}
		
		/// <summary>
		/// Creates a new instance of <see cref="ActionLogger"/> and sets actions list to what you want.
		/// </summary>
		/// <param name="InitialActions">Avoid using <see cref="null"/> on this parameter. Instead, use "new <see cref="ActionLogger"/>();"</param>
		/// <exception cref="ArgumentNullException"/>
		public ActionLogger(string[] InitialActions)
		{
			ShowDate = false;
			Actions = InitialActions ?? throw new ArgumentNullException("InitialActions", "No null allowed here. Instead, use \"new ActionLogger();\".");
		}

		/// <summary>
		/// Gets a string array of all actions logged.
		/// </summary>
		/// <returns>Returns array string.</returns>
		public string[] ReturnPreviousActions()
		{
			return Actions;
		}

		/// <summary>
		/// Gets a string of a specific action.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public string ReturnSpecificAction(int index)
		{
			return Actions[index];
		}

		/// <summary>
		/// Logs new action to the list.
		/// </summary>
		public void LogAction(string description)
		{
			if (ShowDate)
				Actions[Actions.Length - 1] = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "|" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "]" + description;
			else
				Actions[Actions.Length - 1] = description;
		}

		/// <summary>
		/// Removes latest action logged.
		/// </summary>
		/// <remarks>PLEASE NOTE THAT IT JUST NULLIFIES THE ACTION. IT ACTUALLY DOESN'T REMOVE IT.</remarks>
		public void RemoveAction()
		{
			Actions[Actions.Length - 1] = null;
		}

		/// <summary>
		/// Removes specific action logged.
		/// </summary>
		/// <remarks>PLEASE NOTE THAT IT JUST NULLIFIES THE ACTION. IT ACTUALLY DOESN'T REMOVE IT.</remarks>
		public void RemoveAction(int index)
		{
			Actions[index] = null;
		}

		/// <summary>
		/// Overwrites all actions in the list to a specific directory.
		/// </summary>
		/// <exception cref="IOException"/>
		/// <exception cref="Exception"/>
		public void OverwriteAllActions(string path)
		{
			try
			{
				File.WriteAllLines(path, Actions);
			} catch (Exception ex)
			{
				throw ex;
			}
		}
    }
}
