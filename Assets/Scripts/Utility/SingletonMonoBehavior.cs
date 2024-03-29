using UnityEngine;

namespace Utility
{
	public class SingletonMonoBehavior<T> : MonoBehaviour where T : SingletonMonoBehavior<T> {
		protected static SingletonMonoBehavior<T> InternalInstance {
			get {
				if (m_instance)
				{
					return m_instance;
				}

				if (FindObjectsOfType(typeof(T)) is T[] managers && managers.Length != 0)
				{
					if (managers.Length == 1)
					{
						m_instance = managers[0];
						m_instance.gameObject.name = typeof(T).Name;
						return m_instance;
					}

					Debug.LogError("You have more than one " + typeof(T).Name + " in the scene.");
					foreach(T manager in managers)
					{
						Destroy(manager.gameObject);
					}
				}
			
				var gameObject = new GameObject(typeof(T).Name, typeof(T));
				m_instance = gameObject.GetComponent<T>();
				DontDestroyOnLoad(gameObject);
				return m_instance;
			}
			set
			{
				m_instance = value as T;
			} 
		}
		private static T m_instance;
	}
}
