namespace Game.Obj
{
	using Scripts;
	using Zenject;

	public class AppleInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
				Container
					.BindInterfacesTo<ObjFacade>()
					.FromComponentsInHierarchy()
					.AsSingle();
				
				Container
					.BindInterfacesTo<ApplePresenter>()
					.AsSingle();
				
				Container
					.BindInterfacesTo<AppleController>()
					.AsSingle();
				
				Container
					.BindInterfacesTo<AppleView>()
					.FromComponentsInHierarchy()
					.AsSingle();
				
				Container
					.Bind<ObjTouchHandler>()
					.FromComponentInHierarchy()
					.AsSingle();
				
				Container
					.BindInterfacesAndSelfTo<DragComponent>()
					.AsSingle();
				
				Container
					.BindInterfacesAndSelfTo<FallComponent>()
					.AsSingle();
				
				Container
					.Bind<GroundComponent>()
					.FromComponentInHierarchy()
					.AsSingle();
		}
	}
}