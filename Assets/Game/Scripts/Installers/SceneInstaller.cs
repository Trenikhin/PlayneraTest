namespace Game.Installers
{
	using Camera;
	using Input;
	using Zenject;

	public class SceneInstaller : MonoInstaller 
	{
		public override void InstallBindings()
		{
			BindInput();
		}

		void BindInput()
		{
			Container
				.BindInterfacesTo<TouchHandler>()
				.AsSingle();
			
			Container
				.BindInterfacesTo<CameraController>()
				.FromComponentInHierarchy()
				.AsSingle();
			
			Container
				.Bind<ScrollHandler>()
				.FromComponentInHierarchy()
				.AsSingle();
		}
	}
}