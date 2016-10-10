namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module ReactNative =
    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module JSX =
        type Element = obj // added after import

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module NativeMethodsMixin =
        type MeasureOnSuccessCallback =
            Func<float, float, float, float, float, float, unit>

        and MeasureInWindowOnSuccessCallback =
            Func<float, float, float, float, unit>

        and MeasureLayoutOnSuccessCallback =
            Func<float, float, float, float, unit>

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module NavigatorStatic =
        type Route = obj // added after import
        type ViewStyle = obj // added after import

        type NavState =
            abstract routeStack: ResizeArray<Route> with get, set
            abstract idStack: ResizeArray<float> with get, set
            abstract presentedIndex: float with get, set

        and NavigationBarStyle =
            interface end

        and NavigationBarRouteMapper =
            abstract Title: Func<Route, Navigator, float, NavState, React.ReactElement<obj>> with get, set
            abstract LeftButton: Func<Route, Navigator, float, NavState, React.ReactElement<obj>> with get, set
            abstract RightButton: Func<Route, Navigator, float, NavState, React.ReactElement<obj>> with get, set

        and NavigationBarProperties =
            inherit React.Props<NavigationBarStatic>
            abstract navigator: Navigator option with get, set
            abstract routeMapper: NavigationBarRouteMapper option with get, set
            abstract navState: NavState option with get, set
            abstract style: ViewStyle option with get, set

        and NavigationBarStatic =
            inherit React.ComponentClass<NavigationBarProperties>
            abstract Styles: NavigationBarStyle with get, set

        and NavigationBar =
            NavigationBarStatic

        and BreadcrumbNavigationBarStyle =
            interface end

        and BreadcrumbNavigationBarRouteMapper =
            abstract rightContentForRoute: Func<Route, Navigator, React.ReactElement<obj>> with get, set
            abstract titleContentForRoute: Func<Route, Navigator, React.ReactElement<obj>> with get, set
            abstract iconForRoute: Func<Route, Navigator, React.ReactElement<obj>> with get, set
            abstract separatorForRoute: Func<Route, Navigator, React.ReactElement<obj>> with get, set

        and BreadcrumbNavigationBarProperties =
            inherit React.Props<BreadcrumbNavigationBarStatic>
            abstract navigator: Navigator option with get, set
            abstract routeMapper: BreadcrumbNavigationBarRouteMapper option with get, set
            abstract navState: NavState option with get, set
            abstract style: ViewStyle option with get, set

        and BreadcrumbNavigationBarStatic =
            inherit React.ComponentClass<BreadcrumbNavigationBarProperties>
            abstract Styles: BreadcrumbNavigationBarStyle with get, set

        and BreadcrumbNavigationBar =
            BreadcrumbNavigationBarStatic
       
        type [<Import("NavigatorStatic","react-native")>] Globals =
            static member NavigationBar with get(): NavigationBarStatic = failwith "JS only" and set(v: NavigationBarStatic): unit = failwith "JS only"
            static member BreadcrumbNavigationBar with get(): BreadcrumbNavigationBarStatic = failwith "JS only" and set(v: BreadcrumbNavigationBarStatic): unit = failwith "JS only"


    type NativeComponent =
        abstract refs: obj with get, set
        abstract ``measure``: callback: NativeMethodsMixin.MeasureOnSuccessCallback -> unit
        abstract measureInWindow: callback: NativeMethodsMixin.MeasureInWindowOnSuccessCallback -> unit
        abstract measureLayout: relativeToNativeNode: float * onSuccess: NativeMethodsMixin.MeasureLayoutOnSuccessCallback * onFail: Func<unit> -> unit
        abstract setNativeProps: nativeProps: obj -> unit
        abstract focus: unit -> unit
        abstract blur: unit -> unit

    and ReactClass<'D, 'P, 'S> =
        interface end

    and Runnable =
        Func<obj, unit>

    and NativeSyntheticEvent<'T> =
        abstract bubbles: bool with get, set
        abstract cancelable: bool with get, set
        abstract currentTarget: EventTarget with get, set
        abstract defaultPrevented: bool with get, set
        abstract eventPhase: float with get, set
        abstract isTrusted: bool with get, set
        abstract nativeEvent: 'T with get, set
        abstract target: EventTarget with get, set
        abstract timeStamp: DateTime with get, set
        abstract ``type``: string with get, set
        abstract preventDefault: unit -> unit
        abstract stopPropagation: unit -> unit

    and NativeTouchEvent =
        abstract changedTouches: ResizeArray<NativeTouchEvent> with get, set
        abstract identifier: string with get, set
        abstract locationX: float with get, set
        abstract locationY: float with get, set
        abstract pageX: float with get, set
        abstract pageY: float with get, set
        abstract target: string with get, set
        abstract timestamp: float with get, set
        abstract touches: ResizeArray<NativeTouchEvent> with get, set

    and GestureResponderEvent =
        inherit NativeSyntheticEvent<NativeTouchEvent>


    and PointProperties =
        abstract x: float with get, set
        abstract y: float with get, set

    and Insets =
        abstract top: float option with get, set
        abstract left: float option with get, set
        abstract bottom: float option with get, set
        abstract right: float option with get, set

    and Touchable =
        abstract onTouchStart: Func<GestureResponderEvent, unit> option with get, set
        abstract onTouchMove: Func<GestureResponderEvent, unit> option with get, set
        abstract onTouchEnd: Func<GestureResponderEvent, unit> option with get, set
        abstract onTouchCancel: Func<GestureResponderEvent, unit> option with get, set
        abstract onTouchEndCapture: Func<GestureResponderEvent, unit> option with get, set

    and AppConfig =
        obj

    and [<Import("AppRegistry","react-native")>] AppRegistry() =
        static member registerConfig(config: ResizeArray<AppConfig>): unit = failwith "JS only"
        static member registerComponent(appKey: string, getComponentFunc: Func<React.ComponentClass<obj>>): string = failwith "JS only"
        static member registerRunnable(appKey: string, func: Runnable): string = failwith "JS only"
        static member getAppKeys(): ResizeArray<string> = failwith "JS only"
        static member unmountApplicationComponentAtRootTag(rootTag: float): unit = failwith "JS only"
        static member runApplication(appKey: string, appParameters: obj): unit = failwith "JS only"

    and LayoutAnimationTypes =
        abstract spring: string with get, set
        abstract linear: string with get, set
        abstract easeInEaseOut: string with get, set
        abstract easeIn: string with get, set
        abstract easeOut: string with get, set

    and LayoutAnimationProperties =
        abstract opacity: string with get, set
        abstract scaleXY: string with get, set

    and LayoutAnimationAnim =
        abstract duration: float option with get, set
        abstract delay: float option with get, set
        abstract springDamping: float option with get, set
        abstract initialVelocity: float option with get, set
        abstract ``type``: string option with get, set
        abstract property: string option with get, set

    and LayoutAnimationConfig =
        abstract duration: float with get, set
        abstract create: LayoutAnimationAnim option with get, set
        abstract update: LayoutAnimationAnim option with get, set
        abstract delete: LayoutAnimationAnim option with get, set

    and LayoutAnimationStatic =
        abstract configureNext: Func<LayoutAnimationConfig, Func<unit>, Func<obj, unit>, unit> with get, set
        abstract create: Func<float, string, string, LayoutAnimationConfig> with get, set
        abstract Types: LayoutAnimationTypes with get, set
        abstract Properties: LayoutAnimationProperties with get, set
        abstract configChecker: Func<obj, string, string, unit> with get, set
        abstract Presets: obj with get, set

    and [<StringEnum>] FlexAlignType =
        | ``Flex-start`` | ``Flex-end`` | Center | Stretch

    and [<StringEnum>] FlexJustifyType =
        | ``Flex-start`` | ``Flex-end`` | Center | ``Space-between`` | ``Space-around``

    and FlexStyle =

        abstract alignItems: FlexAlignType option with get, set
        abstract alignSelf: (* TODO StringEnum auto |  *) string option with get, set
        abstract borderBottomWidth: float option with get, set
        abstract borderLeftWidth: float option with get, set
        abstract borderRightWidth: float option with get, set
        abstract borderTopWidth: float option with get, set
        abstract borderWidth: float option with get, set
        abstract bottom: float option with get, set
        abstract flex: float option with get, set
        abstract flexDirection: (* TODO StringEnum row | column | row-reverse | column-reverse *) string option with get, set
        abstract flexWrap: (* TODO StringEnum wrap | nowrap *) string option with get, set
        abstract height: float option with get, set
        abstract justifyContent: FlexJustifyType option with get, set
        abstract left: float option with get, set
        abstract minWidth: float option with get, set
        abstract maxWidth: float option with get, set
        abstract minHeight: float option with get, set
        abstract maxHeight: float option with get, set
        abstract margin: float option with get, set
        abstract marginBottom: float option with get, set
        abstract marginHorizontal: float option with get, set
        abstract marginLeft: float option with get, set
        abstract marginRight: float option with get, set
        abstract marginTop: float option with get, set
        abstract marginVertical: float option with get, set
        abstract padding: float option with get, set
        abstract paddingBottom: float option with get, set
        abstract paddingHorizontal: float option with get, set
        abstract paddingLeft: float option with get, set
        abstract paddingRight: float option with get, set
        abstract paddingTop: float option with get, set
        abstract paddingVertical: float option with get, set
        abstract position: (* TODO StringEnum absolute | relative *) string option with get, set
        abstract right: float option with get, set
        abstract top: float option with get, set
        abstract width: float option with get, set
        abstract zIndex: float option with get, set

    and ShadowPropTypesIOSStatic =
        abstract shadowColor: string with get, set
        abstract shadowOffset: obj with get, set
        abstract shadowOpacity: float with get, set
        abstract shadowRadius: float with get, set

    and GetCurrentPositionOptions =
        obj

    and WatchPositionOptions =
        obj

    and GeolocationReturnType =
        obj

    and TransformsStyle =
        abstract transform: obj * obj * obj * obj * obj * obj * obj * obj * obj * obj * obj * obj option with get, set
        abstract transformMatrix: ResizeArray<float> option with get, set
        abstract rotation: float option with get, set
        abstract scaleX: float option with get, set
        abstract scaleY: float option with get, set
        abstract translateX: float option with get, set
        abstract translateY: float option with get, set

    and StyleSheetProperties =
        abstract hairlineWidth: float with get, set
        abstract flatten: style: 'T -> 'T

    and LayoutRectangle =
        abstract x: float with get, set
        abstract y: float with get, set
        abstract width: float with get, set
        abstract height: float with get, set

    and LayoutChangeEvent =
        abstract nativeEvent: obj with get, set

    and TextStyleIOS =
        inherit ViewStyle
        abstract letterSpacing: float option with get, set
        abstract textDecorationColor: string option with get, set
        abstract textDecorationStyle: (* TODO StringEnum solid | double | dotted | dashed *) string option with get, set
        abstract writingDirection: (* TODO StringEnum auto | ltr | rtl *) string option with get, set

    and TextStyleAndroid =
        inherit ViewStyle
        abstract textAlignVertical: (* TODO StringEnum auto | top | bottom | center *) string option with get, set

    and TextStyle =
        inherit TextStyleIOS
        inherit TextStyleAndroid
        inherit ViewStyle
        abstract color: string option with get, set
        abstract fontFamily: string option with get, set
        abstract fontSize: float option with get, set
        abstract fontStyle: (* TODO StringEnum normal | italic *) string option with get, set
        abstract fontWeight: (* TODO StringEnum normal | bold | 100 | 200 | 300 | 400 | 500 | 600 | 700 | 800 | 900 *) string option with get, set
        abstract letterSpacing: float option with get, set
        abstract lineHeight: float option with get, set
        abstract textAlign: (* TODO StringEnum auto | left | right | center *) string option with get, set
        abstract textDecorationLine: (* TODO StringEnum none | underline | line-through | underline line-through *) string option with get, set
        abstract textDecorationStyle: (* TODO StringEnum solid | double | dotted | dashed *) string option with get, set
        abstract textDecorationColor: string option with get, set
        abstract textShadowColor: string option with get, set
        abstract textShadowOffset: obj option with get, set
        abstract textShadowRadius: float option with get, set
        abstract testID: string option with get, set

    and TextPropertiesIOS =
        abstract allowFontScaling: bool with get, set
        abstract suppressHighlighting: bool option with get, set

    and TextProperties =
        inherit React.Props<TextProperties>
        abstract allowFontScaling: bool option with get, set
        abstract lineBreakMode: (* TODO StringEnum head | middle | tail | clip *) string option with get, set
        abstract numberOfLines: float option with get, set
        abstract onLayout: Func<LayoutChangeEvent, unit> option with get, set
        abstract onPress: Func<unit> option with get, set
        abstract style: TextStyle option with get, set
        abstract testID: string option with get, set

    and TextStatic =
        inherit React.ComponentClass<TextProperties>


    and TextInputIOSProperties =
        abstract clearButtonMode: string option with get, set
        abstract clearTextOnFocus: bool option with get, set
        abstract enablesReturnKeyAutomatically: bool option with get, set
        abstract onKeyPress: Func<unit> option with get, set
        abstract selectionState: obj option with get, set

    and TextInputAndroidProperties =
        abstract numberOfLines: float option with get, set
        abstract returnKeyLabel: string option with get, set
        abstract textAlign: string option with get, set
        abstract textAlignVertical: string option with get, set
        abstract underlineColorAndroid: string option with get, set

    and TextInputProperties =
        inherit TextInputIOSProperties
        inherit TextInputAndroidProperties
        inherit React.Props<TextInputStatic>
        abstract autoCapitalize: (* TODO StringEnum none | sentences | words | characters *) string option with get, set
        abstract autoCorrect: bool option with get, set
        abstract autoFocus: bool option with get, set
        abstract blurOnSubmit: bool option with get, set
        abstract defaultValue: string option with get, set
        abstract editable: bool option with get, set
        abstract keyboardType: (* TODO StringEnum default | email-address | numeric | phone-pad | ascii-capable | numbers-and-punctuation | url | number-pad | name-phone-pad | decimal-pad | twitter | web-search *) string option with get, set
        abstract maxLength: float option with get, set
        abstract multiline: bool option with get, set
        abstract onBlur: Func<unit> option with get, set
        abstract onChange: Func<obj, unit> option with get, set
        abstract onChangeText: Func<string, unit> option with get, set
        abstract onEndEditing: Func<obj, unit> option with get, set
        abstract onFocus: Func<unit> option with get, set
        abstract onLayout: Func<obj, unit> option with get, set
        abstract onSelectionChange: Func<unit> option with get, set
        abstract onSubmitEditing: Func<obj, unit> option with get, set
        abstract password: bool option with get, set
        abstract placeholder: string option with get, set
        abstract placeholderTextColor: string option with get, set
        abstract returnKeyType: (* TODO StringEnum default | go | google | join | next | route | search | send | yahoo | done | emergency-call *) string option with get, set
        abstract secureTextEntry: bool option with get, set
        abstract selectTextOnFocus: bool option with get, set
        abstract selectionColor: string option with get, set
        abstract style: TextStyle option with get, set
        abstract testID: string option with get, set
        abstract value: string option with get, set

    and TextInputStatic =
        inherit NativeComponent
        inherit React.ComponentClass<TextInputProperties>
        abstract isFocused: Func<bool> with get, set
        abstract clear: Func<unit> with get, set
        abstract blur: Func<unit> with get, set
        abstract focus: Func<unit> with get, set

    and ToolbarAndroidAction =
        obj

    and ToolbarAndroidProperties =
        inherit ViewProperties
        inherit React.Props<ToolbarAndroidStatic>
        abstract actions: ResizeArray<ToolbarAndroidAction> option with get, set
        abstract contentInsetEnd: float option with get, set
        abstract contentInsetStart: float option with get, set
        abstract logo: obj option with get, set
        abstract navIcon: obj option with get, set
        abstract onActionSelected: Func<float, unit> option with get, set
        abstract onIconClicked: Func<unit> option with get, set
        abstract overflowIcon: obj option with get, set
        abstract rtl: bool option with get, set
        abstract subtitle: string option with get, set
        abstract subtitleColor: string option with get, set
        abstract testID: string option with get, set
        abstract title: string option with get, set
        abstract titleColor: string option with get, set
        abstract ref: Ref<ToolbarAndroidStatic> option with get, set

    and ToolbarAndroidStatic =
        inherit React.ComponentClass<ToolbarAndroidProperties>


    and GestureResponderHandlers =
        abstract onStartShouldSetResponder: Func<GestureResponderEvent, bool> option with get, set
        abstract onMoveShouldSetResponder: Func<GestureResponderEvent, bool> option with get, set
        abstract onResponderGrant: Func<GestureResponderEvent, unit> option with get, set
        abstract onResponderReject: Func<GestureResponderEvent, unit> option with get, set
        abstract onResponderMove: Func<GestureResponderEvent, unit> option with get, set
        abstract onResponderRelease: Func<GestureResponderEvent, unit> option with get, set
        abstract onResponderTerminationRequest: Func<GestureResponderEvent, bool> option with get, set
        abstract onResponderTerminate: Func<GestureResponderEvent, unit> option with get, set
        abstract onStartShouldSetResponderCapture: Func<GestureResponderEvent, bool> option with get, set
        abstract onMoveShouldSetResponderCapture: Func<unit> option with get, set

    and ViewStyle =
        inherit FlexStyle
        inherit TransformsStyle
        abstract backfaceVisibility: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract backgroundColor: string option with get, set
        abstract borderBottomColor: string option with get, set
        abstract borderBottomLeftRadius: float option with get, set
        abstract borderBottomRightRadius: float option with get, set
        abstract borderBottomWidth: float option with get, set
        abstract borderColor: string option with get, set
        abstract borderLeftColor: string option with get, set
        abstract borderRadius: float option with get, set
        abstract borderRightColor: string option with get, set
        abstract borderRightWidth: float option with get, set
        abstract borderStyle: (* TODO StringEnum solid | dotted | dashed *) string option with get, set
        abstract borderTopColor: string option with get, set
        abstract borderTopLeftRadius: float option with get, set
        abstract borderTopRightRadius: float option with get, set
        abstract borderTopWidth: float option with get, set
        abstract opacity: float option with get, set
        abstract overflow: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract shadowColor: string option with get, set
        abstract shadowOffset: obj option with get, set
        abstract shadowOpacity: float option with get, set
        abstract shadowRadius: float option with get, set
        abstract elevation: float option with get, set
        abstract testID: string option with get, set

    and ViewPropertiesIOS =
        abstract accessibilityTraits: U2<string, ResizeArray<string>> option with get, set
        abstract shouldRasterizeIOS: bool option with get, set

    and ViewPropertiesAndroid =
        abstract accessibilityComponentType: string option with get, set
        abstract accessibilityLiveRegion: string option with get, set
        abstract collapsable: bool option with get, set
        abstract importantForAccessibility: string option with get, set
        abstract needsOffscreenAlphaCompositing: bool option with get, set
        abstract renderToHardwareTextureAndroid: bool option with get, set

    and [<StringEnum; RequireQualifiedAccess>] PointerEvents =
        | ``Box-none`` | None | ``Box-only`` | AutoViewStyle
    
    and ViewProperties =
        inherit ViewPropertiesAndroid
        inherit ViewPropertiesIOS
        inherit GestureResponderHandlers
        inherit Touchable
//        inherit React.Props<ViewStatic>
        abstract accessibilityLabel: string option with get, set
        abstract accessible: bool option with get, set
        abstract hitSlop: obj option with get, set
        abstract onAcccessibilityTap: Func<unit> option with get, set
        abstract onLayout: Func<LayoutChangeEvent, unit> option with get, set
        abstract onMagicTap: Func<unit> option with get, set
        abstract pointerEvents: PointerEvents option with get, set
        abstract removeClippedSubviews: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract testID: string option with get, set

    and ViewStatic =
        inherit NativeComponent
        inherit React.ComponentClass<ViewProperties>


    and ViewPagerAndroidOnPageScrollEventData =
        abstract position: float with get, set
        abstract offset: float with get, set

    and ViewPagerAndroidOnPageSelectedEventData =
        abstract position: float with get, set

    and ViewPagerAndroidProperties =
        inherit ViewProperties
        abstract initialPage: float option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract onPageScroll: Func<NativeSyntheticEvent<ViewPagerAndroidOnPageScrollEventData>, unit> option with get, set
        abstract onPageSelected: Func<NativeSyntheticEvent<ViewPagerAndroidOnPageSelectedEventData>, unit> option with get, set
        abstract onPageScrollStateChanged: Func<(* TODO StringEnum Idle | Dragging | Settling *) string, unit> option with get, set
        abstract keyboardDismissMode: (* TODO StringEnum none | on-drag *) string option with get, set
        abstract pageMargin: float option with get, set

    and ViewPagerAndroidStatic =
        inherit NativeComponent
        inherit React.ComponentClass<ViewPagerAndroidProperties>
        abstract setPage: Func<float, unit> with get, set
        abstract setPageWithoutAnimation: Func<float, unit> with get, set

    and KeyboardAvoidingViewStatic =
        inherit React.ComponentClass<KeyboardAvoidingViewProps>


    and KeyboardAvoidingViewProps =
        inherit ViewProperties
        inherit React.Props<KeyboardAvoidingViewStatic>
        abstract behavior: (* TODO StringEnum height | position | padding *) string option with get, set
        abstract keyboardVerticalOffset: float with get, set
        abstract ref: Ref<obj> option with get, set

    and NavState =
        abstract url: string option with get, set
        abstract title: string option with get, set
        abstract loading: bool option with get, set
        abstract canGoBack: bool option with get, set
        abstract canGoForward: bool option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set

    and WebViewPropertiesAndroid =
        abstract javaScriptEnabled: bool option with get, set
        abstract domStorageEnabled: bool option with get, set

    and WebViewIOSLoadRequestEvent =
        abstract target: float with get, set
        abstract canGoBack: bool with get, set
        abstract lockIdentifier: float with get, set
        abstract loading: bool with get, set
        abstract title: string with get, set
        abstract canGoForward: bool with get, set
        abstract navigationType: (* TODO StringEnum other | click *) string with get, set
        abstract url: string with get, set

    and WebViewPropertiesIOS =
        abstract allowsInlineMediaPlayback: bool option with get, set
        abstract bounces: bool option with get, set
        abstract decelerationRate: (* TODO StringEnum normal | fast |  *) string option with get, set
        abstract onShouldStartLoadWithRequest: Func<WebViewIOSLoadRequestEvent, bool> option with get, set
        abstract scrollEnabled: bool option with get, set

    and WebViewUriSource =
        abstract uri: string option with get, set
        abstract ``method``: string option with get, set
        abstract headers: obj option with get, set
        abstract body: string option with get, set

    and WebViewHtmlSource =
        abstract html: string with get, set
        abstract baseUrl: string option with get, set

    and WebViewProperties =
        inherit ViewProperties
        inherit WebViewPropertiesAndroid
        inherit WebViewPropertiesIOS
        inherit React.Props<WebViewStatic>
        abstract automaticallyAdjustContentInsets: bool option with get, set
        abstract bounces: bool option with get, set
        abstract contentInset: Insets option with get, set
        abstract html: string option with get, set
        abstract injectedJavaScript: string option with get, set
        abstract onError: Func<NavState, unit> option with get, set
        abstract onLoad: Func<NavState, unit> option with get, set
        abstract onLoadEnd: Func<NavState, unit> option with get, set
        abstract onLoadStart: Func<NavState, unit> option with get, set
        abstract onNavigationStateChange: Func<NavState, unit> option with get, set
        abstract onShouldStartLoadWithRequest: Func<bool> option with get, set
        abstract renderError: Func<React.ReactElement<ViewProperties>> option with get, set
        abstract renderLoading: Func<React.ReactElement<ViewProperties>> option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract startInLoadingState: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract url: string option with get, set
        abstract source: U3<WebViewUriSource, WebViewHtmlSource, float> option with get, set
        abstract mediaPlaybackRequiresUserAction: bool option with get, set
        abstract scalesPageToFit: bool option with get, set
        abstract ref: Ref<obj> option with get, set

    and WebViewStatic =
        inherit React.ComponentClass<WebViewProperties>
        abstract goBack: Func<unit> with get, set
        abstract goForward: Func<unit> with get, set
        abstract reload: Func<unit> with get, set
        abstract getWebViewHandle: Func<obj> with get, set

    and NativeSegmentedControlIOSChangeEvent =
        abstract value: string with get, set
        abstract selectedSegmentIndex: float with get, set
        abstract target: float with get, set

    and SegmentedControlIOSProperties =
        inherit ViewProperties
        inherit React.Props<SegmentedControlIOSStatic>
        abstract enabled: bool option with get, set
        abstract momentary: bool option with get, set
        abstract onChange: Func<NativeSyntheticEvent<NativeSegmentedControlIOSChangeEvent>, unit> option with get, set
        abstract onValueChange: Func<string, unit> option with get, set
        abstract selectedIndex: float option with get, set
        abstract tintColor: string option with get, set
        abstract values: ResizeArray<string> option with get, set
        abstract ref: Ref<SegmentedControlIOSStatic> option with get, set

    and SegmentedControlIOSStatic =
        inherit React.ComponentClass<SegmentedControlIOSProperties>


    and NavigatorIOSProperties =
        inherit React.Props<NavigatorIOSStatic>
        abstract barTintColor: string option with get, set
        abstract initialRoute: Route option with get, set
        abstract itemWrapperStyle: ViewStyle option with get, set
        abstract navigationBarHidden: bool option with get, set
        abstract shadowHidden: bool option with get, set
        abstract tintColor: string option with get, set
        abstract titleTextColor: string option with get, set
        abstract translucent: bool option with get, set
        abstract style: ViewStyle option with get, set

    and NavigationIOS =
        abstract push: Func<Route, unit> with get, set
        abstract pop: Func<unit> with get, set
        abstract popN: Func<float, unit> with get, set
        abstract replace: Func<Route, unit> with get, set
        abstract replacePrevious: Func<Route, unit> with get, set
        abstract replacePreviousAndPop: Func<Route, unit> with get, set
        abstract resetTo: Func<Route, unit> with get, set
        abstract popToRoute: route: Route -> unit
        abstract popToTop: unit -> unit

    and NavigatorIOSStatic =
        inherit NavigationIOS
        inherit React.ComponentClass<NavigatorIOSProperties>


    and ActivityIndicatorProperties =
        inherit ViewProperties
        inherit React.Props<ActivityIndicatorStatic>
        abstract animating: bool option with get, set
        abstract color: string option with get, set
        abstract hidesWhenStopped: bool option with get, set
        abstract size: (* TODO StringEnum small | large *) string option with get, set
        abstract style: ViewStyle option with get, set
        abstract ref: Ref<ActivityIndicatorStatic> option with get, set

    and ActivityIndicatorStatic =
        inherit React.ComponentClass<ActivityIndicatorProperties>


    and ActivityIndicatorIOSProperties =
        inherit ViewProperties
        inherit React.Props<ActivityIndicatorIOSStatic>
        abstract animating: bool option with get, set
        abstract color: string option with get, set
        abstract hidesWhenStopped: bool option with get, set
        abstract onLayout: Func<obj, unit> option with get, set
        abstract size: (* TODO StringEnum small | large *) string option with get, set
        abstract style: ViewStyle option with get, set
        abstract ref: Ref<ActivityIndicatorIOSStatic> option with get, set

    and ActivityIndicatorIOSStatic =
        inherit React.ComponentClass<ActivityIndicatorIOSProperties>


    and DatePickerIOSProperties =
        inherit ViewProperties
        inherit React.Props<DatePickerIOSStatic>
        abstract date: DateTime option with get, set
        abstract maximumDate: DateTime option with get, set
        abstract minimumDate: DateTime option with get, set
        abstract minuteInterval: float option with get, set
        abstract mode: (* TODO StringEnum date | time | datetime *) string option with get, set
        abstract onDateChange: Func<DateTime, unit> option with get, set
        abstract timeZoneOffsetInMinutes: float option with get, set
        abstract ref: Ref<DatePickerIOSStatic> option with get, set

    and DatePickerIOSStatic =
        inherit React.ComponentClass<DatePickerIOSProperties>


    and DrawerSlideEvent =
        inherit NativeSyntheticEvent<NativeTouchEvent>

    and DrawerLayoutAndroidPosition =
        interface end

    and DrawerLayoutAndroidPositions =
        abstract member Left: DrawerLayoutAndroidPosition
        abstract member Right: DrawerLayoutAndroidPosition

    and DrawerLayoutAndroidProperties =
        inherit ViewProperties
        inherit React.Props<DrawerLayoutAndroidStatic>
        abstract drawerBackgroundColor: string option with get, set
        abstract drawerLockMode: (* TODO StringEnum unlocked | locked-closed | locked-open *) string option with get, set
        abstract drawerPosition: obj option with get, set
        abstract drawerWidth: float option with get, set
        abstract keyboardDismissMode: (* TODO StringEnum none | on-drag *) string option with get, set
        abstract onDrawerClose: Func<unit> option with get, set
        abstract onDrawerOpen: Func<unit> option with get, set
        abstract onDrawerSlide: Func<DrawerSlideEvent, unit> option with get, set
        abstract onDrawerStateChanged: Func<(* TODO StringEnum Idle | Dragging | Settling *) string, unit> option with get, set
        abstract renderNavigationView: Func<JSX.Element> option with get, set
        abstract statusBarBackgroundColor: obj option with get, set
        abstract ref: Ref<obj> option with get, set

    and DrawerLayoutAndroidStatic =
        inherit React.ComponentClass<DrawerLayoutAndroidProperties>
        abstract positions: obj with get, set
        abstract openDrawer: unit -> unit
        abstract closeDrawer: unit -> unit

    and PickerIOSItemProperties =
        inherit React.Props<PickerIOSItemStatic>
        abstract value: U2<string, float> option with get, set
        abstract label: string option with get, set

    and PickerIOSItemStatic =
        inherit React.ComponentClass<PickerIOSItemProperties>


    and PickerItemProperties =
        inherit React.Props<PickerItemStatic>
        abstract label: string with get, set
        abstract value: obj option with get, set
        abstract color: string option with get, set
        abstract testID: string option with get, set

    and PickerItemStatic =
        inherit React.ComponentClass<PickerItemProperties>


    and PickerPropertiesIOS =
        inherit ViewProperties
        inherit React.Props<PickerStatic>
        abstract itemStyle: ViewStyle option with get, set
        abstract ref: Ref<obj> option with get, set

    and PickerPropertiesAndroid =
        inherit ViewProperties
        inherit React.Props<PickerStatic>
        abstract enabled: bool option with get, set
        abstract mode: (* TODO StringEnum dialog | dropdown *) string option with get, set
        abstract prompt: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and PickerProperties =
        inherit PickerPropertiesIOS
        inherit PickerPropertiesAndroid
        inherit React.Props<PickerStatic>
        abstract onValueChange: Func<obj, float, unit> option with get, set
        abstract selectedValue: obj option with get, set
        abstract style: ViewStyle option with get, set
        abstract testId: string option with get, set
        abstract ref: Ref<PickerStatic> option with get, set

    and PickerStatic =
        inherit React.ComponentClass<PickerProperties>
        abstract Item: PickerItemStatic with get, set

    and PickerIOSProperties =
        inherit React.Props<PickerIOSStatic>
        abstract itemStyle: ViewStyle option with get, set

    and PickerIOSStatic =
        inherit React.ComponentClass<PickerIOSProperties>
        abstract Item: PickerIOSItemStatic with get, set

    and ProgressBarAndroidProperties =
        inherit ViewProperties
        inherit React.Props<ProgressBarAndroidStatic>
        abstract style: ViewStyle option with get, set
        abstract styleAttr: (* TODO StringEnum Horizontal | Normal | Small | Large | Inverse | SmallInverse | LargeInverse *) string option with get, set
        abstract indeterminate: bool option with get, set
        abstract progress: float option with get, set
        abstract color: string option with get, set
        abstract testID: string option with get, set
        abstract ref: Ref<ProgressBarAndroidStatic> option with get, set

    and ProgressBarAndroidStatic =
        inherit React.ComponentClass<ProgressBarAndroidProperties>


    and ProgressViewIOSProperties =
        inherit ViewProperties
        inherit React.Props<ProgressViewIOSStatic>
        abstract style: ViewStyle option with get, set
        abstract progressViewStyle: (* TODO StringEnum default | bar *) string option with get, set
        abstract progress: float option with get, set
        abstract progressTintColor: string option with get, set
        abstract trackTintColor: string option with get, set
        abstract progressImage: obj option with get, set
        abstract trackImage: obj option with get, set
        abstract ref: Ref<ProgressViewIOSStatic> option with get, set

    and ProgressViewIOSStatic =
        inherit React.ComponentClass<ProgressViewIOSProperties>


    and RefreshControlPropertiesIOS =
        inherit ViewProperties
        inherit React.Props<RefreshControlStatic>
        abstract tintColor: string option with get, set
        abstract title: string option with get, set
        abstract titleColor: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and RefreshControlPropertiesAndroid =
        inherit ViewProperties
        inherit React.Props<RefreshControlStatic>
        abstract colors: ResizeArray<string> option with get, set
        abstract enabled: bool option with get, set
        abstract progressBackgroundColor: string option with get, set
        abstract size: float option with get, set
        abstract progressViewOffset: float option with get, set
        abstract ref: Ref<obj> option with get, set

    and RefreshControlProperties =
        inherit RefreshControlPropertiesIOS
        inherit RefreshControlPropertiesAndroid
        inherit React.Props<RefreshControl>
        abstract onRefresh: Func<unit> option with get, set
        abstract refreshing: bool option with get, set
        abstract ref: Ref<RefreshControlStatic> option with get, set

    and RefreshControlStatic =
        inherit React.ComponentClass<RefreshControlProperties>
        abstract SIZE: obj with get, set

    and SliderPropertiesIOS =
        inherit ViewProperties
        inherit React.Props<SliderStatic>
        abstract maximumTrackImage: obj option with get, set
        abstract maximumTrackTintColor: string option with get, set
        abstract minimumTrackImage: string option with get, set
        abstract minimumTrackTintColor: string option with get, set
        abstract thumbImage: obj option with get, set
        abstract trackImage: obj option with get, set
        abstract ref: Ref<SliderStatic> option with get, set

    and SliderProperties =
        inherit SliderPropertiesIOS
        inherit React.Props<SliderStatic>
        abstract disabled: bool option with get, set
        abstract maximumValue: float option with get, set
        abstract minimumValue: float option with get, set
        abstract onSlidingComplete: Func<float, unit> option with get, set
        abstract onValueChange: Func<float, unit> option with get, set
        abstract step: float option with get, set
        abstract style: ViewStyle option with get, set
        abstract testID: string option with get, set
        abstract value: float option with get, set

    and SliderStatic =
        inherit React.ComponentClass<SliderProperties>


    and SliderIOSProperties =
        inherit ViewProperties
        inherit React.Props<SliderIOSStatic>
        abstract disabled: bool option with get, set
        abstract maximumValue: float option with get, set
        abstract maximumTrackTintColor: string option with get, set
        abstract minimumValue: float option with get, set
        abstract minimumTrackImage: obj option with get, set
        abstract minimumTrackTintColor: string option with get, set
        abstract onSlidingComplete: Func<unit> option with get, set
        abstract onValueChange: Func<float, unit> option with get, set
        abstract step: float option with get, set
        abstract style: ViewStyle option with get, set
        abstract value: float option with get, set
        abstract ref: Ref<SliderIOSStatic> option with get, set

    and SliderIOSStatic =
        inherit React.ComponentClass<SliderIOSProperties>


    and SwitchIOSStyle =
        inherit ViewStyle
        abstract height: float option with get, set
        abstract width: float option with get, set

    and SwitchIOSProperties =
        inherit React.Props<SwitchIOSStatic>
        abstract disabled: bool option with get, set
        abstract onTintColor: string option with get, set
        abstract onValueChange: Func<bool, unit> option with get, set
        abstract thumbTintColor: string option with get, set
        abstract tintColor: string option with get, set
        abstract value: bool option with get, set
        abstract style: SwitchIOSStyle option with get, set

    and SwitchIOSStatic =
        inherit React.ComponentClass<SwitchIOSProperties>


    and ImageResizeModeStatic =
        abstract contain: string with get, set
        abstract cover: string with get, set
        abstract stretch: string with get, set

    and ImageStyle =
        inherit FlexStyle
        inherit TransformsStyle
        abstract resizeMode: string option with get, set
        abstract backfaceVisibility: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract borderBottomLeftRadius: float option with get, set
        abstract borderBottomRightRadius: float option with get, set
        abstract backgroundColor: string option with get, set
        abstract borderColor: string option with get, set
        abstract borderWidth: float option with get, set
        abstract borderRadius: float option with get, set
        abstract borderTopLeftRadius: float option with get, set
        abstract borderTopRightRadius: float option with get, set
        abstract overflow: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract overlayColor: string option with get, set
        abstract tintColor: string option with get, set
        abstract opacity: float option with get, set

    and ImagePropertiesIOS =
        abstract accessibilityLabel: string option with get, set
        abstract accessible: bool option with get, set
        abstract capInsets: Insets option with get, set
        abstract defaultSource: U2<obj, float> option with get, set
        abstract onError: Func<obj, unit> option with get, set
        abstract onProgress: Func<unit> option with get, set

    and ImageProperties =
        inherit ImagePropertiesIOS
        inherit React.Props<Image>
        abstract onLayout: Func<LayoutChangeEvent, unit> option with get, set
        abstract onLoad: Func<unit> option with get, set
        abstract onLoadEnd: Func<unit> option with get, set
        abstract onLoadStart: Func<unit> option with get, set
        abstract resizeMode: (* TODO StringEnum cover | contain | stretch *) string option with get, set
        abstract source: U2<obj, string> with get, set
        abstract style: ImageStyle option with get, set
        abstract testID: string option with get, set

    and ImageStatic =
        inherit React.ComponentClass<ImageProperties>
        abstract uri: string with get, set
        abstract resizeMode: ImageResizeModeStatic with get, set
        abstract getSize: uri: string * success: Func<float, float, unit> * failure: Func<obj, unit> -> obj
        abstract prefetch: url: string -> obj

    and ListViewProperties<'a> =
        inherit ScrollViewProperties
        inherit React.Props<ListViewStatic<'a>>
        abstract dataSource: ListViewDataSource<'a> option with get, set
        abstract enableEmptySections: bool option with get, set
        abstract initialListSize: float option with get, set
        abstract onChangeVisibleRows: Func<ResizeArray<obj>, ResizeArray<obj>, unit> option with get, set
        abstract onEndReached: Func<unit> option with get, set
        abstract onEndReachedThreshold: float option with get, set
        abstract pageSize: float option with get, set
        abstract removeClippedSubviews: bool option with get, set
        abstract renderFooter: Func<React.ReactElement<obj>> option with get, set
        abstract renderHeader: Func<React.ReactElement<obj>> option with get, set
        abstract renderRow: Func<obj, U2<string, float>, U2<string, float>, bool, React.ReactElement<obj>> option with get, set
        abstract renderScrollComponent: Func<ScrollViewProperties, React.ReactElement<ScrollViewProperties>> option with get, set
        abstract renderSectionHeader: Func<obj, U2<string, float>, React.ReactElement<obj>> option with get, set
        abstract renderSeparator: Func<U2<string, float>, U2<string, float>, bool, React.ReactElement<obj>> option with get, set
        abstract scrollRenderAheadDistance: float option with get, set
        abstract ref: Ref<obj> option with get, set

    and ListViewStatic<'a> =
        inherit React.ComponentClass<ListViewProperties<'a>>
        abstract DataSource: ListViewDataSource<'a> with get, set

    and MapViewAnnotation =
        abstract latitude: float option with get, set
        abstract longitude: float option with get, set
        abstract animateDrop: bool option with get, set
        abstract title: string option with get, set
        abstract subtitle: string option with get, set
        abstract hasLeftCallout: bool option with get, set
        abstract hasRightCallout: bool option with get, set
        abstract onLeftCalloutPress: Func<unit> option with get, set
        abstract onRightCalloutPress: Func<unit> option with get, set
        abstract id: string option with get, set

    and MapViewRegion =
        abstract latitude: float with get, set
        abstract longitude: float with get, set
        abstract latitudeDelta: float option with get, set
        abstract longitudeDelta: float option with get, set

    and MapViewOverlay =
        abstract coordinates: ResizeArray<obj> with get, set
        abstract lineWidth: float option with get, set
        abstract strokeColor: obj option with get, set
        abstract fillColor: obj option with get, set
        abstract id: string option with get, set

    and MapViewPropertiesIOS =
        abstract showsPointsOfInterest: bool option with get, set
        abstract annotations: ResizeArray<MapViewAnnotation> option with get, set
        abstract followUserLocation: bool option with get, set
        abstract legalLabelInsets: Insets option with get, set
        abstract mapType: string option with get, set
        abstract maxDelta: float option with get, set
        abstract minDelta: float option with get, set
        abstract overlays: ResizeArray<MapViewOverlay> with get, set
        abstract showsCompass: bool option with get, set

    and MapViewPropertiesAndroid =
        abstract active: bool option with get, set

    and MapViewProperties =
        inherit MapViewPropertiesIOS
        inherit MapViewPropertiesAndroid
        inherit Touchable
        inherit ViewProperties
        inherit React.Props<MapViewStatic>
        abstract onAnnotationPress: Func<unit> option with get, set
        abstract onRegionChange: Func<MapViewRegion, unit> option with get, set
        abstract onRegionChangeComplete: Func<MapViewRegion, unit> option with get, set
        abstract pitchEnabled: bool option with get, set
        abstract region: MapViewRegion option with get, set
        abstract rotateEnabled: bool option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract showsUserLocation: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract zoomEnabled: bool option with get, set
        abstract ref: Ref<obj> option with get, set

    and MapViewStatic =
        inherit React.ComponentClass<MapViewProperties>


    and ModalProperties =
        inherit React.Props<ModalStatic>
        abstract animated: bool option with get, set
        abstract animationType: (* TODO StringEnum none | slide | fade *) string option with get, set
        abstract transparent: bool option with get, set
        abstract visible: bool option with get, set
        abstract onRequestClose: Func<unit> option with get, set
        abstract onShow: Func<NativeSyntheticEvent<obj>, unit> option with get, set

    and ModalStatic =
        inherit React.ComponentClass<ModalProperties>


    and TouchableWithoutFeedbackAndroidProperties =
        abstract accessibilityComponentType: string option with get, set

    and TouchableWithoutFeedbackIOSProperties =
        abstract accessibilityTraits: U2<string, ResizeArray<string>> option with get, set

    and TouchableWithoutFeedbackProperties =
        inherit TouchableWithoutFeedbackAndroidProperties
        inherit TouchableWithoutFeedbackIOSProperties
        abstract accessible: bool option with get, set
        abstract delayLongPress: float option with get, set
        abstract delayPressIn: float option with get, set
        abstract delayPressOut: float option with get, set
        abstract disabled: bool option with get, set
        abstract hitSlop: obj option with get, set
        abstract onLayout: Func<LayoutChangeEvent, unit> option with get, set
        abstract onLongPress: Func<unit> option with get, set
        abstract onPress: Func<unit> option with get, set
        abstract onPressIn: Func<unit> option with get, set
        abstract onPressOut: Func<unit> option with get, set
        abstract style: ViewStyle option with get, set
        abstract pressRetentionOffset: obj option with get, set

    and TouchableWithoutFeedbackProps =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableWithoutFeedbackStatic>


    and TouchableWithoutFeedbackStatic =
        inherit React.ComponentClass<TouchableWithoutFeedbackProps>


    and TouchableHighlightProperties =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableHighlightStatic>
        abstract activeOpacity: float option with get, set
        abstract onHideUnderlay: Func<unit> option with get, set
        abstract onShowUnderlay: Func<unit> option with get, set
        abstract style: ViewStyle option with get, set
        abstract underlayColor: string option with get, set

    and TouchableHighlightStatic =
        inherit React.ComponentClass<TouchableHighlightProperties>


    and TouchableOpacityProperties =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableOpacityStatic>
        abstract activeOpacity: float option with get, set

    and TouchableOpacityStatic =
        inherit React.ComponentClass<TouchableOpacityProperties>
        abstract setOpacityTo: Func<float, unit> with get, set

    and TouchableNativeFeedbackProperties =
        inherit TouchableWithoutFeedbackProperties
        inherit React.Props<TouchableNativeFeedbackStatic>
        abstract background: obj option with get, set

    and TouchableNativeFeedbackStatic =
        inherit React.ComponentClass<TouchableNativeFeedbackProperties>
        abstract SelectableBackground: Func<TouchableNativeFeedbackStatic> with get, set
        abstract SelectableBackgroundBorderless: Func<TouchableNativeFeedbackStatic> with get, set
        abstract Ripple: Func<string, bool, TouchableNativeFeedbackStatic> with get, set

    and LeftToRightGesture =
        interface end

    and AnimationInterpolator =
        interface end

    and SceneConfig =
        abstract gestures: obj with get, set
        abstract springFriction: float with get, set
        abstract springTension: float with get, set
        abstract defaultTransitionVelocity: float with get, set
        abstract animationInterpolators: obj with get, set

    and SceneConfigs =
        abstract PushFromRight: SceneConfig with get, set
        abstract FloatFromRight: SceneConfig with get, set
        abstract FloatFromLeft: SceneConfig with get, set
        abstract FloatFromBottom: SceneConfig with get, set
        abstract FloatFromBottomAndroid: SceneConfig with get, set
        abstract FadeAndroid: SceneConfig with get, set
        abstract HorizontalSwipeJump: SceneConfig with get, set
        abstract HorizontalSwipeJumpFromRight: SceneConfig with get, set
        abstract VerticalUpSwipeJump: SceneConfig with get, set
        abstract VerticalDownSwipeJump: SceneConfig with get, set

    and Route =
        abstract ``component``: React.ComponentClass<ViewProperties> option with get, set
        abstract id: string option with get, set
        abstract title: string option with get, set
        abstract passProps: obj option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set
        abstract backButtonTitle: string option with get, set
        abstract content: string option with get, set
        abstract message: string option with get, set
        abstract index: int option with get, set
        abstract onRightButtonPress: Func<unit> option with get, set
        abstract rightButtonTitle: string option with get, set
        abstract sceneConfig: SceneConfig option with get, set
        abstract wrapperStyle: obj option with get, set

    and NavigatorProperties =
        inherit React.Props<Navigator>
        abstract configureScene: Func<Route, ResizeArray<Route>, SceneConfig> option with get, set
        abstract initialRoute: Route option with get, set
        abstract initialRouteStack: ResizeArray<Route> option with get, set
        abstract navigationBar: React.ReactElement<NavigatorStatic.NavigationBarProperties> option with get, set
        abstract navigator: Navigator option with get, set
        abstract onDidFocus: Function option with get, set
        abstract onWillFocus: Function option with get, set
        abstract renderScene: Func<Route, Navigator, React.ReactElement<ViewProperties>> option with get, set
        abstract sceneStyle: ViewStyle option with get, set
        abstract debugOverlay: bool option with get, set

    and NavigationContext =
        abstract parent: NavigationContext with get, set
        abstract top: NavigationContext with get, set
        abstract currentRoute: obj with get, set
        abstract appendChild: childContext: NavigationContext -> unit
        abstract addListener: eventType: string * listener: Func<unit> * ?useCapture: bool -> NativeEventSubscription
        abstract emit: eventType: string * data: obj * ?didEmitCallback: Func<unit> -> unit
        abstract dispose: unit -> unit

    and NavigatorStatic =
        inherit React.ComponentClass<NavigatorProperties>
        abstract SceneConfigs: SceneConfigs with get, set
        abstract NavigationBar: NavigatorStatic.NavigationBarStatic with get, set
        abstract BreadcrumbNavigationBar: NavigatorStatic.BreadcrumbNavigationBarStatic with get, set
        abstract navigationContext: NavigationContext with get, set
        abstract getContext: self: obj -> NavigatorStatic
        abstract getCurrentRoutes: unit -> ResizeArray<Route>
        abstract jumpBack: unit -> unit
        abstract jumpForward: unit -> unit
        abstract jumpTo: route: Route -> unit
        abstract push: route: Route -> unit
        abstract pop: unit -> unit
        abstract replace: route: Route -> unit
        abstract replaceAtIndex: route: Route * index: float -> unit
        abstract replacePrevious: route: Route -> unit
        abstract immediatelyResetRouteStack: routes: ResizeArray<Route> -> unit
        abstract popToRoute: route: Route -> unit
        abstract popToTop: unit -> unit
        abstract replacePreviousAndPop: route: Route -> unit
        abstract resetTo: route: Route -> unit

    and StyleSheetStatic =
        inherit React.ComponentClass<StyleSheetProperties>
        abstract hairlineWidth: float with get, set
        abstract absoluteFill: float with get, set
        abstract absoluteFillObject: obj with get, set
        abstract create: styles: 'T -> 'T
        abstract flatten: style: obj -> obj

    and DataSourceAssetCallback =
        abstract rowHasChanged: Func<obj, obj, bool> option with get, set
        abstract sectionHeaderHasChanged: Func<obj, obj, bool> option with get, set
        abstract getRowData: Func<obj, U2<float, string>, U2<float, string>, 'T> option with get, set
        abstract getSectionHeaderData: Func<obj, U2<float, string>, 'T> option with get, set

    and ListViewDataSource<'a> =
        [<Emit("new $0($1...)")>] abstract Create: onAsset: DataSourceAssetCallback -> ListViewDataSource<'a>
        abstract cloneWithRows: dataBlob: U2<ResizeArray<obj>, obj> * ?rowIdentities: ResizeArray<U2<string, float>> -> ListViewDataSource<'a>
        abstract cloneWithRowsAndSections: dataBlob: U2<ResizeArray<obj>, obj> * ?sectionIdentities: ResizeArray<U2<string, float>> * ?rowIdentities: ResizeArray<ResizeArray<U2<string, float>>> -> ListViewDataSource<'a>
        abstract getRowCount: unit -> int
        abstract getRowData: sectionIndex: float * rowIndex: float -> obj
        abstract getRowIDForFlatIndex: index: float -> string
        abstract getSectionIDForFlatIndex: index: float -> string
        abstract getSectionLengths: unit -> ResizeArray<float>
        abstract sectionHeaderShouldUpdate: sectionIndex: float -> bool
        abstract getSectionHeaderData: sectionIndex: float -> obj

    and TabBarItemProperties =
        inherit ViewProperties
        inherit React.Props<TabBarItemStatic>
        abstract badge: U2<string, float> option with get, set
        abstract icon: U2<obj, string> option with get, set
        abstract onPress: Func<unit> option with get, set
        abstract selected: bool option with get, set
        abstract selectedIcon: U2<obj, string> option with get, set
        abstract style: ViewStyle option with get, set
        abstract systemIcon: (* TODO StringEnum bookmarks | contacts | downloads | favorites | featured | history | more | most-recent | most-viewed | recents | search | top-rated *) string with get, set
        abstract title: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and TabBarItemStatic =
        inherit React.ComponentClass<TabBarItemProperties>


    and TabBarIOSProperties =
        inherit ViewProperties
        inherit React.Props<TabBarIOSStatic>
        abstract barTintColor: string option with get, set
        abstract style: ViewStyle option with get, set
        abstract tintColor: string option with get, set
        abstract translucent: bool option with get, set
        abstract unselectedTintColor: string option with get, set
        abstract ref: Ref<obj> option with get, set

    and TabBarIOSStatic =
        inherit React.ComponentClass<TabBarIOSProperties>
        abstract Item: TabBarItemStatic with get, set

    and PixelRatioStatic =
        abstract get: unit -> float
        abstract getFontScale: unit -> float
        abstract getPixelSizeForLayoutSize: layoutSize: float -> float
        abstract roundToNearestPixel: layoutSize: float -> float
        abstract startDetecting: unit -> unit

    and [<StringEnum>] PlatformOSType =
        | Ios | Android

    and PlatformStatic =
        abstract OS: PlatformOSType with get, set
        abstract select: specifics: obj -> 'T

    and DeviceEventSubscriptionStatic =
        abstract remove: unit -> unit

    and DeviceEventEmitterStatic =
        abstract addListener: ``type``: string * onReceived: Func<'T, unit> -> DeviceEventSubscription
        abstract removeListener: eventType: string * listener: Function -> unit

    and ScaledSize =
        abstract width: float with get, set
        abstract height: float with get, set
        abstract scale: float with get, set
        abstract fontScale: float with get, set

    and Dimensions =
        abstract get: dim: (* TODO StringEnum window | screen *) string -> ScaledSize
        abstract set: dims: ResizeArray<obj> -> unit

    and PromiseTask =
        obj

    and Handle =
        float

    and InteractionManagerStatic =
        abstract runAfterInteractions: fn: Func<U2<unit, PromiseTask>> -> obj
        abstract createInteractionHandle: unit -> Handle
        abstract clearInteractionHandle: handle: Handle -> unit
        abstract setDeadline: deadline: float -> unit

    and ScrollViewStyle =
        inherit FlexStyle
        inherit TransformsStyle
        abstract backfaceVisibility: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract backgroundColor: string option with get, set
        abstract borderColor: string option with get, set
        abstract borderTopColor: string option with get, set
        abstract borderRightColor: string option with get, set
        abstract borderBottomColor: string option with get, set
        abstract borderLeftColor: string option with get, set
        abstract borderRadius: float option with get, set
        abstract borderTopLeftRadius: float option with get, set
        abstract borderTopRightRadius: float option with get, set
        abstract borderBottomLeftRadius: float option with get, set
        abstract borderBottomRightRadius: float option with get, set
        abstract borderStyle: (* TODO StringEnum solid | dotted | dashed *) string option with get, set
        abstract borderWidth: float option with get, set
        abstract borderTopWidth: float option with get, set
        abstract borderRightWidth: float option with get, set
        abstract borderBottomWidth: float option with get, set
        abstract borderLeftWidth: float option with get, set
        abstract opacity: float option with get, set
        abstract overflow: (* TODO StringEnum visible | hidden *) string option with get, set
        abstract shadowColor: string option with get, set
        abstract shadowOffset: obj option with get, set
        abstract shadowOpacity: float option with get, set
        abstract shadowRadius: float option with get, set
        abstract elevation: float option with get, set

    and ScrollViewPropertiesIOS =
        abstract alwaysBounceHorizontal: bool option with get, set
        abstract alwaysBounceVertical: bool option with get, set
        abstract automaticallyAdjustContentInsets: bool option with get, set
        abstract bounces: bool option with get, set
        abstract bouncesZoom: bool option with get, set
        abstract canCancelContentTouches: bool option with get, set
        abstract centerContent: bool option with get, set
        abstract contentInset: Insets option with get, set
        abstract contentOffset: PointProperties option with get, set
        abstract decelerationRate: (* TODO StringEnum fast | normal |  *) string option with get, set
        abstract directionalLockEnabled: bool option with get, set
        abstract indicatorStyle: (* TODO StringEnum default | black | white *) string option with get, set
        abstract maximumZoomScale: float option with get, set
        abstract minimumZoomScale: float option with get, set
        abstract onRefreshStart: Func<unit> option with get, set
        abstract onScrollAnimationEnd: Func<unit> option with get, set
        abstract scrollEnabled: bool option with get, set
        abstract scrollEventThrottle: float option with get, set
        abstract scrollIndicatorInsets: Insets option with get, set
        abstract scrollsToTop: bool option with get, set
        abstract snapToAlignment: string option with get, set
        abstract snapToInterval: float option with get, set
        abstract stickyHeaderIndices: ResizeArray<float> option with get, set
        abstract zoomScale: float option with get, set

    and ScrollViewPropertiesAndroid =
        abstract endFillColor: string option with get, set
        abstract scrollPerfTag: string option with get, set

    and ScrollViewProperties =
        inherit ViewProperties
        inherit ScrollViewPropertiesIOS
        inherit ScrollViewPropertiesAndroid
        inherit Touchable
//        inherit React.Props<ScrollViewStatic>
        abstract contentContainerStyle: ViewStyle option with get, set
        abstract horizontal: bool option with get, set
        abstract keyboardDismissMode: string option with get, set
        abstract keyboardShouldPersistTaps: bool option with get, set
        abstract onScroll: Func<obj, unit> option with get, set
        abstract pagingEnabled: bool option with get, set
        abstract removeClippedSubviews: bool option with get, set
        abstract showsHorizontalScrollIndicator: bool option with get, set
        abstract showsVerticalScrollIndicator: bool option with get, set
        abstract style: ScrollViewStyle option with get, set
        abstract refreshControl: React.ReactElement<RefreshControlProperties> option with get, set
        abstract ref: Ref<obj> option with get, set

    and ScrollViewProps =
        // inherit ScrollViewProperties
        inherit React.Props<ScrollViewStatic>
        abstract ref: Ref<ScrollViewStatic> option with get, set

    and ScrollViewStatic =
        inherit React.ComponentClass<ScrollViewProps>
        abstract endRefreshing: Func<unit> option with get, set
        abstract scrollWithoutAnimationTo: Func<float, float, unit> option with get, set
        abstract scrollTo: ?y: U2<float, obj> * ?x: float * ?animated: bool -> unit
        abstract getScrollResponder: unit -> JSX.Element
        abstract getInnerViewNode: unit -> obj

    and NativeScrollRectangle =
        abstract left: float with get, set
        abstract top: float with get, set
        abstract bottom: float with get, set
        abstract right: float with get, set

    and NativeScrollPoint =
        abstract x: float with get, set
        abstract y: float with get, set

    and NativeScrollSize =
        abstract height: float with get, set
        abstract width: float with get, set

    and NativeScrollEvent =
        abstract contentInset: NativeScrollRectangle with get, set
        abstract contentOffset: NativeScrollPoint with get, set
        abstract contentSize: NativeScrollSize with get, set
        abstract layoutMeasurement: NativeScrollSize with get, set
        abstract zoomScale: float with get, set

    and SwipeableListViewDataSource<'a> =
        abstract cloneWithRowsAndSections: dataBlob: obj * sectionIdentities: ResizeArray<string> * rowIdentities: ResizeArray<ResizeArray<string>> -> SwipeableListViewDataSource<'a>
        abstract getDataSource: unit -> ListViewDataSource<'a>
        abstract getOpenRowID: unit -> string
        abstract setOpenRowID: rowID: string -> ListViewDataSource<'a>

    and SwipeableListViewProps<'a> =
        inherit React.Props<SwipeableListViewStatic<'a>>
        abstract dataSource: SwipeableListViewDataSource<'a> with get, set
        abstract maxSwipeDistance: float option with get, set
        abstract renderRow: Func<obj, U2<string, float>, U2<string, float>, bool, React.ReactElement<obj>> with get, set
        abstract renderQuickActions: rowData: obj * sectionID: string * rowID: string -> React.ReactElement<obj>

    and SwipeableListViewStatic<'a> =
        inherit React.ComponentClass<SwipeableListViewProps<'a>>
        abstract getNewDataSource: unit -> SwipeableListViewDataSource<'a>

    and ActionSheetIOSOptions =
        abstract title: string option with get, set
        abstract options: ResizeArray<string> option with get, set
        abstract cancelButtonIndex: float option with get, set
        abstract destructiveButtonIndex: float option with get, set
        abstract message: string option with get, set

    and ShareActionSheetIOSOptions =
        abstract message: string option with get, set
        abstract url: string option with get, set

    and ActionSheetIOSStatic =
        abstract showActionSheetWithOptions: Func<ActionSheetIOSOptions, Func<float, unit>, unit> with get, set
        abstract showShareActionSheetWithOptions: Func<ShareActionSheetIOSOptions, Func<Error, unit>, Func<bool, string, unit>, unit> with get, set

    and AlertButton =
        abstract text: string option with get, set
        abstract onPress: Func<unit> option with get, set
        abstract style: (* TODO StringEnum default | cancel | destructive *) string option with get, set

    and AlertStatic =
        abstract alert: Func<string, string, ResizeArray<AlertButton>, string, unit> with get, set

    and AdSupportIOSStatic =
        abstract getAdvertisingId: Func<Func<string, unit>, Func<Error, unit>, unit> with get, set
        abstract getAdvertisingTrackingEnabled: Func<Func<bool, unit>, Func<Error, unit>, unit> with get, set

    and AlertIOSButton =
        abstract text: string with get, set
        abstract onPress: Func<unit> option with get, set
        abstract style: (* TODO StringEnum default | cancel | destructive *) string option with get, set

    and AlertIOSStatic =
        abstract alert: Func<string, string, Func<string, U2<unit, ResizeArray<AlertIOSButton>>>, string, unit> with get, set
        abstract prompt: Func<string, string, Func<string, U2<unit, ResizeArray<AlertIOSButton>>>, string, string, unit> with get, set

    and [<StringEnum>] AppStateEvent =
        | Change | MemoryWarning

    and [<StringEnum>] AppStateStatus =
        | Active | Background | Inactive

    and AppStateStatic =
        abstract currentState: string with get, set
        abstract addEventListener: ``type``: AppStateEvent * listener: Func<AppStateStatus, unit> -> unit
        abstract removeEventListener: ``type``: AppStateEvent * listener: Func<AppStateStatus, unit> -> unit

    and AsyncStorageStatic =
        abstract getItem: key: string * ?callback: Func<Error, string, unit> -> Promise<string>
        abstract setItem: key: string * value: string * ?callback: Func<Error, unit> -> Promise<string>
        abstract removeItem: key: string * ?callback: Func<Error, unit> -> Promise<string>
        abstract mergeItem: key: string * value: string * ?callback: Func<Error, unit> -> Promise<string>
        abstract clear: ?callback: Func<Error, unit> -> Promise<string>
        abstract getAllKeys: ?callback: Func<Error, ResizeArray<string>, unit> -> Promise<string>
        abstract multiGet: keys: ResizeArray<string> * ?callback: Func<ResizeArray<Error>, ResizeArray<ResizeArray<string>>, unit> -> Promise<string>
        abstract multiSet: keyValuePairs: ResizeArray<ResizeArray<string>> * ?callback: Func<ResizeArray<Error>, unit> -> Promise<string>
        abstract multiRemove: keys: ResizeArray<string> * ?callback: Func<ResizeArray<Error>, unit> -> Promise<string>
        abstract multiMerge: keyValuePairs: ResizeArray<ResizeArray<string>> * ?callback: Func<ResizeArray<Error>, unit> -> Promise<string>

    and BackAndroidStatic =
        abstract exitApp: unit -> unit
        abstract addEventListener: eventName: string * handler: Func<unit> -> unit
        abstract removeEventListener: eventName: string * handler: Func<unit> -> unit

    and CameraRollFetchParams =
        abstract first: float with get, set
        abstract after: string option with get, set
        abstract groupTypes: string with get, set
        abstract groupName: string option with get, set
        abstract assetType: string option with get, set

    and CameraRollNodeInfo =
        abstract image: Image with get, set
        abstract group_name: string with get, set
        abstract timestamp: float with get, set
        abstract location: obj with get, set

    and CameraRollEdgeInfo =
        abstract node: CameraRollNodeInfo with get, set

    and CameraRollAssetInfo =
        abstract edges: ResizeArray<CameraRollEdgeInfo> with get, set
        abstract page_info: obj with get, set

    and GetPhotosParamType =
        abstract first: float with get, set
        abstract after: string with get, set
        abstract groupTypes: (* TODO StringEnum Album | All | Event | Faces | Library | PhotoStream | SavedPhotos *) string with get, set
        abstract groupName: string with get, set
        abstract assetType: (* TODO StringEnum All | Videos | Photos *) string with get, set
        abstract mimeTypes: ResizeArray<string> with get, set

    and GetPhotosReturnType =
        abstract edges: ResizeArray<obj> with get, set
        abstract page_info: obj with get, set

    and CameraRollStatic =
        abstract GroupTypesOptions: ResizeArray<string> with get, set
        abstract saveImageWithTag: tag: string -> Promise<string>
        abstract saveToCameraRoll: tag: string * ?``type``: (* TODO StringEnum photo | video *) string -> Promise<string>
        abstract getPhotos: ``params``: GetPhotosParamType -> Promise<GetPhotosReturnType>

    and ClipboardStatic =
        abstract getString: unit -> Promise<string>
        abstract setString: content: string -> unit

    and DatePickerAndroidOpenOption =
        abstract date: U2<DateTime, float> option with get, set
        abstract minDate: U2<DateTime, float> option with get, set
        abstract maxDate: U2<DateTime, float> option with get, set

    and DatePickerAndroidOpenReturn =
        abstract action: string with get, set
        abstract year: float option with get, set
        abstract month: float option with get, set
        abstract day: float option with get, set

    and DatePickerAndroidStatic =
        abstract dateSetAction: string with get, set
        abstract dismissedAction: string with get, set
        abstract ``open``: ?options: DatePickerAndroidOpenOption -> Promise<DatePickerAndroidOpenReturn>

    and FetchableListenable<'T> =
        abstract fetch: Func<Promise<'T>> with get, set
        abstract addEventListener: Func<string, Func<'T, unit>, unit> with get, set
        abstract removeEventListener: Func<string, Func<'T, unit>, unit> with get, set

    and IntentAndroidStatic =
        abstract openURL: url: string -> unit
        abstract canOpenURL: url: string * callback: Func<bool, unit> -> unit
        abstract getInitialURL: callback: Func<string, unit> -> unit

    and LinkingStatic =
        abstract addEventListener: ``type``: string * handler: Func<obj, unit> -> unit
        abstract removeEventListener: ``type``: string * handler: Func<obj, unit> -> unit
        abstract openURL: url: string -> Promise<bool>
        abstract canOpenURL: url: string -> Promise<bool>
        abstract getInitialURL: unit -> Promise<string>

    and LinkingIOSStatic =
        abstract addEventListener: ``type``: string * handler: Func<obj, unit> -> unit
        abstract removeEventListener: ``type``: string * handler: Func<obj, unit> -> unit
        abstract openURL: url: string -> unit
        abstract canOpenURL: url: string * callback: Func<bool, unit> -> unit
        abstract popInitialURL: unit -> string

    and [<StringEnum; RequireQualifiedAccess>] NetInfoReturnType =
        | None | Wifi | Cell | Unknown | [<CompiledName("NONE")>] NONE | [<CompiledName("MOBILE")>] MOBILE | [<CompiledName("WIFI")>] WIFI | [<CompiledName("MOBILE_MMS")>] MOBILE_MMS | [<CompiledName("MOBILE_SUPL")>] MOBILE_SUPL | [<CompiledName("MOBILE_DUN")>] MOBILE_DUN | [<CompiledName("MOBILE_HIPRI")>] MOBILE_HIPRI | [<CompiledName("WIMAX")>] WIMAX | [<CompiledName("BLUETOOTH")>] BLUETOOTH | [<CompiledName("DUMMY")>] DUMMY | [<CompiledName("ETHERNET")>] ETHERNET | [<CompiledName("MOBILE_FOTA")>] MOBILE_FOTA | [<CompiledName("MOBILE_IMS")>] MOBILE_IMS | [<CompiledName("MOBILE_CBS")>] MOBILE_CBS | [<CompiledName("WIFI_P2P")>] WIFI_P2P | [<CompiledName("MOBILE_IA")>] MOBILE_IA | [<CompiledName("MOBILE_EMERGENCY")>] MOBILE_EMERGENCY | [<CompiledName("PROXY")>] PROXY | [<CompiledName("VPN")>] VPN | [<CompiledName("UNKNOWN")>] UNKNOWN

    and NetInfoStatic =
        inherit FetchableListenable<NetInfoReturnType>
        abstract isConnected: FetchableListenable<bool> with get, set
        abstract isConnectionExpensive: FetchableListenable<bool> with get, set

    and PanResponderGestureState =
        abstract stateID: float with get, set
        abstract moveX: float with get, set
        abstract moveY: float with get, set
        abstract x0: float with get, set
        abstract y0: float with get, set
        abstract dx: float with get, set
        abstract dy: float with get, set
        abstract vx: float with get, set
        abstract vy: float with get, set
        abstract numberActiveTouches: float with get, set
        abstract _accountsForMovesUpTo: float with get, set

    and PanResponderCallbacks =
        abstract onMoveShouldSetPanResponder: Func<GestureResponderEvent, PanResponderGestureState, bool> option with get, set
        abstract onStartShouldSetPanResponder: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderGrant: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderMove: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderRelease: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderTerminate: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onMoveShouldSetPanResponderCapture: Func<GestureResponderEvent, PanResponderGestureState, bool> option with get, set
        abstract onStartShouldSetPanResponderCapture: Func<GestureResponderEvent, PanResponderGestureState, bool> option with get, set
        abstract onPanResponderReject: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderStart: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderEnd: Func<GestureResponderEvent, PanResponderGestureState, unit> option with get, set
        abstract onPanResponderTerminationRequest: Func<GestureResponderEvent, PanResponderGestureState, bool> option with get, set

    and PanResponderInstance =
        abstract panHandlers: GestureResponderHandlers with get, set

    and PanResponderStatic =
        abstract create: config: PanResponderCallbacks -> PanResponderInstance

    and PushNotificationPermissions =
        abstract alert: bool option with get, set
        abstract badge: bool option with get, set
        abstract sound: bool option with get, set

    and PushNotification =
        abstract getMessage: unit -> U2<string, obj>
        abstract getSound: unit -> string
        abstract getAlert: unit -> U2<string, obj>
        abstract getBadgeCount: unit -> float
        abstract getData: unit -> obj

    and PresentLocalNotificationDetails =
        obj

    and ScheduleLocalNotificationDetails =
        obj

    and PushNotificationIOSStatic =
        abstract presentLocalNotification: details: PresentLocalNotificationDetails -> unit
        abstract scheduleLocalNotification: details: ScheduleLocalNotificationDetails -> unit
        abstract cancelAllLocalNotifications: unit -> unit
        abstract cancelLocalNotifications: userInfo: obj -> unit
        abstract setApplicationIconBadgeNumber: number: float -> unit
        abstract getApplicationIconBadgeNumber: callback: Func<float, unit> -> unit
        abstract addEventListener: ``type``: string * handler: Func<PushNotification, unit> -> unit
        abstract requestPermissions: ?permissions: ResizeArray<PushNotificationPermissions> -> Promise<PushNotificationPermissions>
        abstract abandonPermissions: unit -> unit
        abstract checkPermissions: callback: Func<PushNotificationPermissions, unit> -> unit
        abstract removeEventListener: ``type``: string * handler: Func<PushNotification, unit> -> unit
        abstract popInitialNotification: unit -> PushNotification

    and [<StringEnum>] StatusBarStyle =
        | Default | ``Light-content``

    and [<StringEnum; RequireQualifiedAccess>] StatusBarAnimation =
        | None | Fade | Slide

    and StatusBarPropertiesIOS =
        inherit React.Props<StatusBarStatic>
        abstract barStyle: StatusBarStyle option with get, set
        abstract networkActivityIndicatorVisible: bool option with get, set
        abstract showHideTransition: (* TODO StringEnum fade | slide *) string option with get, set

    and StatusBarPropertiesAndroid =
        inherit React.Props<StatusBarStatic>
        abstract backgroundColor: obj option with get, set
        abstract translucent: bool option with get, set

    and StatusBarProperties =
        inherit StatusBarPropertiesIOS
        inherit StatusBarPropertiesAndroid
        inherit React.Props<StatusBarStatic>
        abstract animated: bool option with get, set
        abstract hidden: bool option with get, set

    and StatusBarStatic =
        inherit React.ComponentClass<StatusBarProperties>
        abstract setHidden: Func<bool, StatusBarAnimation, unit> with get, set
        abstract setBarStyle: Func<StatusBarStyle, bool, unit> with get, set
        abstract setNetworkActivityIndicatorVisible: Func<bool, unit> with get, set
        abstract setBackgroundColor: Func<string, bool, unit> with get, set
        abstract setTranslucent: Func<bool, unit> with get, set

    and StatusBarIOSStatic =
        interface end

    and TimePickerAndroidOpenOptions =
        obj

    and TimePickerAndroidStatic =
        abstract timeSetAction: string with get, set
        abstract dismissedAction: string with get, set
        abstract ``open``: options: TimePickerAndroidOpenOptions -> Promise<obj>

    and ToastAndroidStatic =
        abstract SHORT: float with get, set
        abstract LONG: float with get, set
        abstract show: message: string * duration: float -> unit

    and SwitchPropertiesIOS =
        inherit ViewProperties
        inherit React.Props<SwitchStatic>
        abstract onTintColor: string option with get, set
        abstract thumbTintColor: string option with get, set
        abstract tintColor: string option with get, set
        abstract ref: Ref<SwitchStatic> option with get, set

    and SwitchProperties =
        inherit ViewProperties
        inherit React.Props<SwitchStatic>
        abstract disabled: bool option with get, set
        abstract onValueChange: Func<bool, unit> option with get, set
        abstract testID: string option with get, set
        abstract value: bool option with get, set
        abstract style: ViewStyle option with get, set
        abstract ref: Ref<SwitchStatic> option with get, set

    and SwitchStatic =
        inherit React.ComponentClass<SwitchProperties>


    and VibrationIOSStatic =
        abstract vibrate: unit -> unit

    and VibrationStatic =
        abstract vibrate: pattern: U2<float, ResizeArray<float>> * repeat: bool -> unit
        abstract cancel: unit -> unit

    and EasingFunction =
        Func<float, float>

    and EasingStatic =
        abstract step0: EasingFunction with get, set
        abstract step1: EasingFunction with get, set
        abstract linear: EasingFunction with get, set
        abstract ease: EasingFunction with get, set
        abstract quad: EasingFunction with get, set
        abstract cubic: EasingFunction with get, set
        abstract poly: EasingFunction with get, set
        abstract sin: EasingFunction with get, set
        abstract circle: EasingFunction with get, set
        abstract exp: EasingFunction with get, set
        abstract elastic: EasingFunction with get, set
        abstract bounce: EasingFunction with get, set
        abstract back: s: float -> EasingFunction
        abstract bezier: x1: float * y1: float * x2: float * y2: float -> EasingFunction
        abstract ``in``: easing: EasingFunction -> EasingFunction
        abstract out: easing: EasingFunction -> EasingFunction
        abstract inOut: easing: EasingFunction -> EasingFunction

    and GeolocationStatic =
        abstract getCurrentPosition: geo_success: Func<GeolocationReturnType, unit> * ?geo_error: Func<Error, unit> * ?geo_options: GetCurrentPositionOptions -> unit
        abstract watchPosition: success: Func<Geolocation, unit> * ?error: Func<Error, unit> * ?options: WatchPositionOptions -> unit
        abstract clearWatch: watchID: float -> unit
        abstract stopObserving: unit -> unit

    and fetch =
        Func<string, obj, Promise<obj>>

    and timedScheduler =
        Func<U2<string, Function>, float, float>

    and untimedScheduler =
        Func<U2<string, Function>, float>

    and setTimeout =
        timedScheduler

    and setInterval =
        timedScheduler

    and setImmediate =
        untimedScheduler

    and requestAnimationFrame =
        untimedScheduler

    and schedulerCanceller =
        Func<float, unit>

    and clearTimeout =
        schedulerCanceller

    and clearInterval =
        schedulerCanceller

    and clearImmediate =
        schedulerCanceller

    and cancelAnimationFrame =
        schedulerCanceller

    and TabsReducerStatic =
        abstract JumpToAction: index: float -> obj

    and TabsReducerFunction =
        Func<obj, obj>

    and NavigationReducerStatic =
        abstract TabsReducer: obj with get, set

    and NavigationTab =
        abstract key: string with get, set

    and NavigationAction =
        abstract ``type``: string with get, set

    and NavigationRoute =
        abstract key: string with get, set

    and NavigationState =
        inherit NavigationRoute
        abstract index: float with get, set
        abstract routes: ResizeArray<NavigationRoute> with get, set

    and NavigationRenderer =
        Func<NavigationState, Func<NavigationAction, bool>, JSX.Element>

    and NavigationAnimatedViewStaticProps =
        abstract route: obj option with get, set
        abstract style: ViewStyle option with get, set
        abstract renderOverlay: props: obj -> JSX.Element
        abstract applyAnimation: pos: obj * navState: obj -> unit
        abstract renderScene: props: obj -> JSX.Element

    and NavigationAnimatedViewStatic =
        inherit React.ComponentClass<NavigationAnimatedViewStaticProps>


    and NavigationHeaderProps =
        abstract renderTitleComponent: props: obj -> JSX.Element
        abstract onNavigateBack: unit -> unit

    and NavigationHeaderStatic =
        inherit React.ComponentClass<NavigationHeaderProps>
        abstract Title: JSX.Element with get, set
        abstract HEIGHT: float with get, set

    and NavigationCardStackProps =
        abstract direction: (* TODO StringEnum horizontal | vertical *) string option with get, set
        abstract style: ViewStyle option with get, set
        abstract route: obj option with get, set
        abstract renderScene: props: obj -> JSX.Element
        abstract onNavigateBack: unit -> unit

    and NavigationCardStackStatic =
        inherit React.ComponentClass<NavigationCardStackProps>


    and NavigationExperimentalStatic =
        abstract AnimatedView: NavigationAnimatedViewStatic with get, set
        abstract CardStack: NavigationCardStackStatic with get, set
        abstract Header: NavigationHeaderStatic with get, set
        abstract Reducer: NavigationReducerStatic with get, set

    and NavigationContainerProps =
        abstract tabs: ResizeArray<NavigationTab> with get, set
        abstract index: float with get, set

    and NavigationContainerStatic =
        inherit React.ComponentClass<NavigationContainerProps>
        abstract create: inClass: obj -> obj

    and NavigationRootContainerProps =
        inherit React.Props<NavigationRootContainerStatic>
        abstract renderNavigation: NavigationRenderer with get, set
        abstract reducer: NavigationReducerStatic with get, set
        abstract persistenceKey: string option with get, set

    and NavigationRootContainerStatic =
        inherit React.ComponentClass<NavigationRootContainerProps>
        abstract getBackAction: unit -> NavigationAction
        abstract handleNavigation: action: NavigationAction -> bool

    and NativeEventSubscription =
        abstract remove: unit -> unit

    and NativeAppEventEmitterStatic =
        abstract addListener: ``event``: string * handler: Func<obj, unit> -> NativeEventSubscription

    and ActivityIndicator =
        ActivityIndicatorStatic

    and ActivityIndicatorIOS =
        ActivityIndicatorIOSStatic

    and DatePickerIOS =
        DatePickerIOSStatic

    and DrawerLayoutAndroid =
        DrawerLayoutAndroidStatic

    and Image =
        ImageStatic

    and LayoutAnimation =
        LayoutAnimationStatic

    and ListView<'a> =
        ListViewStatic<'a>

    and MapView =
        MapViewStatic

    and Modal =
        ModalStatic

    and Navigator =
        NavigatorStatic

    and NavigatorIOS =
        NavigatorIOSStatic

    and Picker =
        PickerStatic

    and PickerIOS =
        PickerIOSStatic

    and ProgressBarAndroid =
        ProgressBarAndroidStatic

    and ProgressViewIOS =
        ProgressViewIOSStatic

    and RefreshControl =
        RefreshControlStatic

    and Slider =
        SliderIOS

    and SliderIOS =
        SliderIOSStatic

    and StatusBar =
        StatusBarStatic

    and ScrollView =
        ScrollViewStatic

    and StyleSheet =
        StyleSheetStatic

    and SwipeableListView<'a> =
        SwipeableListViewStatic<'a>

    and Switch =
        SwitchStatic

    and SwitchIOS =
        SwitchIOSStatic

    and TabBarIOS =
        TabBarIOSStatic

    and Text =
        TextStatic

    and TextInput =
        TextInputStatic

    and ToolbarAndroid =
        ToolbarAndroidStatic

    and TouchableHighlight =
        TouchableHighlightStatic

    and TouchableNativeFeedback =
        TouchableNativeFeedbackStatic

    and TouchableOpacity =
        TouchableOpacityStatic

    and TouchableWithoutFeedback =
        TouchableWithoutFeedbackStatic

    and View =
        ViewStatic

    and ViewPagerAndroid =
        ViewPagerAndroidStatic

    and WebView =
        WebViewStatic

    and ActionSheetIOS =
        ActionSheetIOSStatic

    and AdSupportIOS =
        AdSupportIOSStatic

    and Alert =
        AlertStatic

    and AlertIOS =
        AlertIOSStatic

    and AppState =
        AppStateStatic

    and AppStateIOS =
        AppStateStatic

    and AsyncStorage =
        AsyncStorageStatic

    and BackAndroid =
        BackAndroidStatic

    and CameraRoll =
        CameraRollStatic

    and Clipboard =
        ClipboardStatic

    and DatePickerAndroid =
        DatePickerAndroidStatic

    and IntentAndroid =
        IntentAndroidStatic

    and KeyboardAvoidingView =
        KeyboardAvoidingViewStatic

    and Linking =
        LinkingStatic

    and LinkingIOS =
        LinkingIOSStatic

    and NetInfo =
        NetInfoStatic

    and PanResponder =
        PanResponderStatic

    and PushNotificationIOS =
        PushNotificationIOSStatic

    and StatusBarIOS =
        StatusBarIOSStatic

    and TimePickerAndroid =
        TimePickerAndroidStatic

    and ToastAndroid =
        ToastAndroidStatic

    and VibrationIOS =
        VibrationIOSStatic

    and Vibration =
        VibrationStatic

    and NavigationExperimental =
        NavigationExperimentalStatic

    and NavigationContainer =
        NavigationContainerStatic

    and NavigationRootContainer =
        NavigationRootContainerStatic

    and NavigationReducer =
        NavigationReducerStatic

    and Easing =
        EasingStatic

    and ComponentInterface<'P> =
        abstract name: string option with get, set
        abstract displayName: string option with get, set
        abstract propTypes: 'P with get, set

    and SegmentedControlIOS =
        SegmentedControlIOSStatic

    and DeviceEventSubscription =
        DeviceEventSubscriptionStatic

    and Geolocation =
        GeolocationStatic

    and GlobalStatic =
        abstract requestAnimationFrame: fn: Func<unit> -> unit

    type Globals =
        [<Import("ActivityIndicator", "react-native")>] static member ActivityIndicator with get(): ActivityIndicatorStatic = failwith "JS only" and set(v: ActivityIndicatorStatic): unit = failwith "JS only"
        [<Import("ActivityIndicatorIOS", "react-native")>] static member ActivityIndicatorIOS with get(): ActivityIndicatorIOSStatic = failwith "JS only" and set(v: ActivityIndicatorIOSStatic): unit = failwith "JS only"
        [<Import("DatePickerIOS", "react-native")>] static member DatePickerIOS with get(): DatePickerIOSStatic = failwith "JS only" and set(v: DatePickerIOSStatic): unit = failwith "JS only"
        [<Import("DrawerLayoutAndroid", "react-native")>] static member DrawerLayoutAndroid with get(): DrawerLayoutAndroidStatic = failwith "JS only" and set(v: DrawerLayoutAndroidStatic): unit = failwith "JS only"
        [<Import("Image", "react-native")>] static member Image with get(): ImageStatic = failwith "JS only" and set(v: ImageStatic): unit = failwith "JS only"
        [<Import("LayoutAnimation", "react-native")>] static member LayoutAnimation with get(): LayoutAnimationStatic = failwith "JS only" and set(v: LayoutAnimationStatic): unit = failwith "JS only"
        [<Import("ListView", "react-native")>] static member ListView with get(): ListViewStatic<obj> = failwith "JS only" and set(v: ListViewStatic<obj>): unit = failwith "JS only"
        [<Import("MapView", "react-native")>] static member MapView with get(): MapViewStatic = failwith "JS only" and set(v: MapViewStatic): unit = failwith "JS only"
        [<Import("Modal", "react-native")>] static member Modal with get(): ModalStatic = failwith "JS only" and set(v: ModalStatic): unit = failwith "JS only"
        [<Import("Navigator", "react-native")>] static member Navigator with get(): NavigatorStatic = failwith "JS only" and set(v: NavigatorStatic): unit = failwith "JS only"
        [<Import("NavigatorIOS", "react-native")>] static member NavigatorIOS with get(): NavigatorIOSStatic = failwith "JS only" and set(v: NavigatorIOSStatic): unit = failwith "JS only"
        [<Import("Picker", "react-native")>] static member Picker with get(): PickerStatic = failwith "JS only" and set(v: PickerStatic): unit = failwith "JS only"
        [<Import("PickerItem", "react-native")>] static member PickerItem with get(): PickerItemStatic = failwith "JS only" and set(v: PickerItemStatic): unit = failwith "JS only"
        [<Import("PickerIOS", "react-native")>] static member PickerIOS with get(): PickerIOSStatic = failwith "JS only" and set(v: PickerIOSStatic): unit = failwith "JS only"
        [<Import("PickerIOSItem", "react-native")>] static member PickerIOSItem with get(): PickerIOSItemStatic = failwith "JS only" and set(v: PickerIOSItemStatic): unit = failwith "JS only"
        [<Import("ProgressBarAndroid", "react-native")>] static member ProgressBarAndroid with get(): ProgressBarAndroidStatic = failwith "JS only" and set(v: ProgressBarAndroidStatic): unit = failwith "JS only"
        [<Import("ProgressViewIOS", "react-native")>] static member ProgressViewIOS with get(): ProgressViewIOSStatic = failwith "JS only" and set(v: ProgressViewIOSStatic): unit = failwith "JS only"
        [<Import("RefreshControl", "react-native")>] static member RefreshControl with get(): RefreshControlStatic = failwith "JS only" and set(v: RefreshControlStatic): unit = failwith "JS only"
        [<Import("Slider", "react-native")>] static member Slider with get(): SliderIOS = failwith "JS only" and set(v: SliderIOS): unit = failwith "JS only"
        [<Import("SliderIOS", "react-native")>] static member SliderIOS with get(): SliderIOSStatic = failwith "JS only" and set(v: SliderIOSStatic): unit = failwith "JS only"
        [<Import("StatusBar", "react-native")>] static member StatusBar with get(): StatusBarStatic = failwith "JS only" and set(v: StatusBarStatic): unit = failwith "JS only"
        [<Import("ScrollView", "react-native")>] static member ScrollView with get(): ScrollViewStatic = failwith "JS only" and set(v: ScrollViewStatic): unit = failwith "JS only"
        [<Import("StyleSheet", "react-native")>] static member StyleSheet with get(): StyleSheetStatic = failwith "JS only" and set(v: StyleSheetStatic): unit = failwith "JS only"
        [<Import("SwipeableListView", "react-native")>] static member SwipeableListView with get(): SwipeableListViewStatic<obj> = failwith "JS only" and set(v: SwipeableListViewStatic<obj>): unit = failwith "JS only"
        [<Import("Switch", "react-native")>] static member Switch with get(): SwitchStatic = failwith "JS only" and set(v: SwitchStatic): unit = failwith "JS only"
        [<Import("SwitchIOS", "react-native")>] static member SwitchIOS with get(): SwitchIOSStatic = failwith "JS only" and set(v: SwitchIOSStatic): unit = failwith "JS only"
        [<Import("TabBarItem", "react-native")>] static member TabBarItem with get(): TabBarItemStatic = failwith "JS only" and set(v: TabBarItemStatic): unit = failwith "JS only"
        [<Import("TabBarIOS", "react-native")>] static member TabBarIOS with get(): TabBarIOSStatic = failwith "JS only" and set(v: TabBarIOSStatic): unit = failwith "JS only"
        [<Import("Text", "react-native")>] static member Text with get(): TextStatic = failwith "JS only" and set(v: TextStatic): unit = failwith "JS only"
        [<Import("TextInput", "react-native")>] static member TextInput with get(): TextInputStatic = failwith "JS only" and set(v: TextInputStatic): unit = failwith "JS only"
        [<Import("ToolbarAndroid", "react-native")>] static member ToolbarAndroid with get(): ToolbarAndroidStatic = failwith "JS only" and set(v: ToolbarAndroidStatic): unit = failwith "JS only"
        [<Import("TouchableHighlight", "react-native")>] static member TouchableHighlight with get(): TouchableHighlightStatic = failwith "JS only" and set(v: TouchableHighlightStatic): unit = failwith "JS only"
        [<Import("TouchableNativeFeedback", "react-native")>] static member TouchableNativeFeedback with get(): TouchableNativeFeedbackStatic = failwith "JS only" and set(v: TouchableNativeFeedbackStatic): unit = failwith "JS only"
        [<Import("TouchableOpacity", "react-native")>] static member TouchableOpacity with get(): TouchableOpacityStatic = failwith "JS only" and set(v: TouchableOpacityStatic): unit = failwith "JS only"
        [<Import("TouchableWithoutFeedback", "react-native")>] static member TouchableWithoutFeedback with get(): TouchableWithoutFeedbackStatic = failwith "JS only" and set(v: TouchableWithoutFeedbackStatic): unit = failwith "JS only"
        [<Import("View", "react-native")>] static member View with get(): ViewStatic = failwith "JS only" and set(v: ViewStatic): unit = failwith "JS only"
        [<Import("ViewPagerAndroid", "react-native")>] static member ViewPagerAndroid with get(): ViewPagerAndroidStatic = failwith "JS only" and set(v: ViewPagerAndroidStatic): unit = failwith "JS only"
        [<Import("WebView", "react-native")>] static member WebView with get(): WebViewStatic = failwith "JS only" and set(v: WebViewStatic): unit = failwith "JS only"
        [<Import("ActionSheetIOS", "react-native")>] static member ActionSheetIOS with get(): ActionSheetIOSStatic = failwith "JS only" and set(v: ActionSheetIOSStatic): unit = failwith "JS only"
        [<Import("AdSupportIOS", "react-native")>] static member AdSupportIOS with get(): AdSupportIOSStatic = failwith "JS only" and set(v: AdSupportIOSStatic): unit = failwith "JS only"
        [<Import("Alert", "react-native")>] static member Alert with get(): AlertStatic = failwith "JS only" and set(v: AlertStatic): unit = failwith "JS only"
        [<Import("AlertIOS", "react-native")>] static member AlertIOS with get(): AlertIOSStatic = failwith "JS only" and set(v: AlertIOSStatic): unit = failwith "JS only"
        [<Import("AppState", "react-native")>] static member AppState with get(): AppStateStatic = failwith "JS only" and set(v: AppStateStatic): unit = failwith "JS only"
        [<Import("AppStateIOS", "react-native")>] static member AppStateIOS with get(): AppStateStatic = failwith "JS only" and set(v: AppStateStatic): unit = failwith "JS only"
        [<Import("AsyncStorage", "react-native")>] static member AsyncStorage with get(): AsyncStorageStatic = failwith "JS only" and set(v: AsyncStorageStatic): unit = failwith "JS only"
        [<Import("BackAndroid", "react-native")>] static member BackAndroid with get(): BackAndroidStatic = failwith "JS only" and set(v: BackAndroidStatic): unit = failwith "JS only"
        [<Import("CameraRoll", "react-native")>] static member CameraRoll with get(): CameraRollStatic = failwith "JS only" and set(v: CameraRollStatic): unit = failwith "JS only"
        [<Import("Clipboard", "react-native")>] static member Clipboard with get(): ClipboardStatic = failwith "JS only" and set(v: ClipboardStatic): unit = failwith "JS only"
        [<Import("DatePickerAndroid", "react-native")>] static member DatePickerAndroid with get(): DatePickerAndroidStatic = failwith "JS only" and set(v: DatePickerAndroidStatic): unit = failwith "JS only"
        [<Import("IntentAndroid", "react-native")>] static member IntentAndroid with get(): IntentAndroidStatic = failwith "JS only" and set(v: IntentAndroidStatic): unit = failwith "JS only"
        [<Import("KeyboardAvoidingView", "react-native")>] static member KeyboardAvoidingView with get(): KeyboardAvoidingViewStatic = failwith "JS only" and set(v: KeyboardAvoidingViewStatic): unit = failwith "JS only"
        [<Import("Linking", "react-native")>] static member Linking with get(): LinkingStatic = failwith "JS only" and set(v: LinkingStatic): unit = failwith "JS only"
        [<Import("LinkingIOS", "react-native")>] static member LinkingIOS with get(): LinkingIOSStatic = failwith "JS only" and set(v: LinkingIOSStatic): unit = failwith "JS only"
        [<Import("NetInfo", "react-native")>] static member NetInfo with get(): NetInfoStatic = failwith "JS only" and set(v: NetInfoStatic): unit = failwith "JS only"
        [<Import("PanResponder", "react-native")>] static member PanResponder with get(): PanResponderStatic = failwith "JS only" and set(v: PanResponderStatic): unit = failwith "JS only"
        [<Import("PushNotificationIOS", "react-native")>] static member PushNotificationIOS with get(): PushNotificationIOSStatic = failwith "JS only" and set(v: PushNotificationIOSStatic): unit = failwith "JS only"
        [<Import("StatusBarIOS", "react-native")>] static member StatusBarIOS with get(): StatusBarIOSStatic = failwith "JS only" and set(v: StatusBarIOSStatic): unit = failwith "JS only"
        [<Import("TimePickerAndroid", "react-native")>] static member TimePickerAndroid with get(): TimePickerAndroidStatic = failwith "JS only" and set(v: TimePickerAndroidStatic): unit = failwith "JS only"
        [<Import("ToastAndroid", "react-native")>] static member ToastAndroid with get(): ToastAndroidStatic = failwith "JS only" and set(v: ToastAndroidStatic): unit = failwith "JS only"
        [<Import("VibrationIOS", "react-native")>] static member VibrationIOS with get(): VibrationIOSStatic = failwith "JS only" and set(v: VibrationIOSStatic): unit = failwith "JS only"
        [<Import("Vibration", "react-native")>] static member Vibration with get(): VibrationStatic = failwith "JS only" and set(v: VibrationStatic): unit = failwith "JS only"
        [<Import("Dimensions", "react-native")>] static member Dimensions with get(): Dimensions = failwith "JS only" and set(v: Dimensions): unit = failwith "JS only"
        [<Import("ShadowPropTypesIOS", "react-native")>] static member ShadowPropTypesIOS with get(): ShadowPropTypesIOSStatic = failwith "JS only" and set(v: ShadowPropTypesIOSStatic): unit = failwith "JS only"
        [<Import("NavigationExperimental", "react-native")>] static member NavigationExperimental with get(): NavigationExperimentalStatic = failwith "JS only" and set(v: NavigationExperimentalStatic): unit = failwith "JS only"
        [<Import("NavigationContainer", "react-native")>] static member NavigationContainer with get(): NavigationContainerStatic = failwith "JS only" and set(v: NavigationContainerStatic): unit = failwith "JS only"
        [<Import("NavigationRootContainer", "react-native")>] static member NavigationRootContainer with get(): NavigationRootContainerStatic = failwith "JS only" and set(v: NavigationRootContainerStatic): unit = failwith "JS only"
        [<Import("NavigationReducer", "react-native")>] static member NavigationReducer with get(): NavigationReducerStatic = failwith "JS only" and set(v: NavigationReducerStatic): unit = failwith "JS only"
        [<Import("NavigationAnimatedView", "react-native")>] static member NavigationAnimatedView with get(): NavigationAnimatedViewStatic = failwith "JS only" and set(v: NavigationAnimatedViewStatic): unit = failwith "JS only"
        [<Import("NavigationHeader", "react-native")>] static member NavigationHeader with get(): NavigationHeaderStatic = failwith "JS only" and set(v: NavigationHeaderStatic): unit = failwith "JS only"
        [<Import("NavigationCardStack", "react-native")>] static member NavigationCardStack with get(): NavigationCardStackStatic = failwith "JS only" and set(v: NavigationCardStackStatic): unit = failwith "JS only"
        [<Import("Easing", "react-native")>] static member Easing with get(): EasingStatic = failwith "JS only" and set(v: EasingStatic): unit = failwith "JS only"
        [<Import("NativeModules", "react-native")>] static member NativeModules with get(): obj = failwith "JS only" and set(v: obj): unit = failwith "JS only"
        [<Import("NativeAppEventEmitter", "react-native")>] static member NativeAppEventEmitter with get(): NativeAppEventEmitterStatic = failwith "JS only" and set(v: NativeAppEventEmitterStatic): unit = failwith "JS only"
        [<Import("SegmentedControlIOS", "react-native")>] static member SegmentedControlIOS with get(): SegmentedControlIOSStatic = failwith "JS only" and set(v: SegmentedControlIOSStatic): unit = failwith "JS only"
        [<Import("PixelRatio", "react-native")>] static member PixelRatio with get(): PixelRatioStatic = failwith "JS only" and set(v: PixelRatioStatic): unit = failwith "JS only"
        [<Import("Platform", "react-native")>] static member Platform with get(): PlatformStatic = failwith "JS only" and set(v: PlatformStatic): unit = failwith "JS only"
        [<Import("DeviceEventEmitter", "react-native")>] static member DeviceEventEmitter with get(): DeviceEventEmitterStatic = failwith "JS only" and set(v: DeviceEventEmitterStatic): unit = failwith "JS only"
        [<Import("DeviceEventSubscription", "react-native")>] static member DeviceEventSubscription with get(): DeviceEventSubscriptionStatic = failwith "JS only" and set(v: DeviceEventSubscriptionStatic): unit = failwith "JS only"
        [<Import("InteractionManager", "react-native")>] static member InteractionManager with get(): InteractionManagerStatic = failwith "JS only" and set(v: InteractionManagerStatic): unit = failwith "JS only"
        [<Import("Geolocation", "react-native")>] static member Geolocation with get(): GeolocationStatic = failwith "JS only" and set(v: GeolocationStatic): unit = failwith "JS only"
        [<Import("createElement", "react-native")>] static member createElement(``type``: React.ReactType, props: 'P, [<ParamArray>] children: React.ReactNode[]): React.ReactElement<'P> = failwith "JS only"
        [<Import("requireNativeComponent", "react-native")>] static member requireNativeComponent(viewName: string, ?componentInterface: ComponentInterface<'P>, ?extraConfig: obj): React.ComponentClass<'P> = failwith "JS only"
        [<Import("___spread", "react-native")>] static member ___spread(target: obj, [<ParamArray>] sources: obj[]): obj = failwith "JS only"


    module Animated =
        type AnimatedValue =
            Animated

        and AnimatedValueXY =
            ValueXY

        and Base =
            Animated

        and [<Import("Animated.Animated","react-native")>] Animated() =
            class end

        and [<Import("Animated.AnimatedWithChildren","react-native")>] AnimatedWithChildren() =
            inherit Animated()


        and [<Import("Animated.AnimatedInterpolation","react-native")>] AnimatedInterpolation() =
            inherit AnimatedWithChildren()
            member __.interpolate(config: InterpolationConfigType): AnimatedInterpolation = failwith "JS only"

        and [<StringEnum>] ExtrapolateType =
                | Extend | Identity | Clamp

        and InterpolationConfigType =
            obj

        and ValueListenerCallback =
            Func<obj, unit>

        and [<Import("Animated.Value","react-native")>] Value(value: float) =
            inherit AnimatedWithChildren()
            member __.setValue(value: float): unit = failwith "JS only"
            member __.setOffset(offset: float): unit = failwith "JS only"
            member __.flattenOffset(): unit = failwith "JS only"
            member __.addListener(callback: ValueListenerCallback): string = failwith "JS only"
            member __.removeListener(id: string): unit = failwith "JS only"
            member __.removeAllListeners(): unit = failwith "JS only"
            member __.stopAnimation(?callback: Func<float, unit>): unit = failwith "JS only"
            member __.interpolate(config: InterpolationConfigType): AnimatedInterpolation = failwith "JS only"

        and ValueXYListenerCallback =
            Func<obj, unit>

        and [<Import("Animated.ValueXY","react-native")>] ValueXY(?valueIn: obj) =
            inherit AnimatedWithChildren()
            member __.x with get(): AnimatedValue = failwith "JS only" and set(v: AnimatedValue): unit = failwith "JS only"
            member __.y with get(): AnimatedValue = failwith "JS only" and set(v: AnimatedValue): unit = failwith "JS only"
            member __.setValue(value: obj): unit = failwith "JS only"
            member __.setOffset(offset: obj): unit = failwith "JS only"
            member __.flattenOffset(): unit = failwith "JS only"
            member __.stopAnimation(?callback: Func<float>): unit = failwith "JS only"
            member __.addListener(callback: ValueXYListenerCallback): string = failwith "JS only"
            member __.removeListener(id: string): unit = failwith "JS only"
            member __.getLayout(): obj = failwith "JS only"
            member __.getTranslateTransform(): ResizeArray<obj> = failwith "JS only"

        and EndResult =
            obj

        and EndCallback =
            Func<EndResult, unit>

        and CompositeAnimation =
            abstract start: Func<EndCallback, unit> with get, set
            abstract stop: Func<unit> with get, set

        and AnimationConfig =
            abstract isInteraction: bool option with get, set
            abstract useNativeDriver: bool option with get, set

        and DecayAnimationConfig =
            inherit AnimationConfig
            abstract velocity: U2<float, obj> with get, set
            abstract deceleration: float option with get, set

        and TimingAnimationConfig =
            inherit AnimationConfig
            abstract toValue: U4<float, AnimatedValue, obj, AnimatedValueXY> with get, set
            abstract easing: Func<float, float> option with get, set
            abstract duration: float option with get, set
            abstract delay: float option with get, set

        and SpringAnimationConfig =
            inherit AnimationConfig
            abstract toValue: U4<float, AnimatedValue, obj, AnimatedValueXY> with get, set
            abstract overshootClamping: bool option with get, set
            abstract restDisplacementThreshold: float option with get, set
            abstract restSpeedThreshold: float option with get, set
            abstract velocity: U2<float, obj> option with get, set
            abstract bounciness: float option with get, set
            abstract speed: float option with get, set
            abstract tension: float option with get, set
            abstract friction: float option with get, set

        and [<Import("Animated.AnimatedAddition","react-native")>] AnimatedAddition() =
            inherit AnimatedInterpolation()


        and [<Import("Animated.AnimatedMultiplication","react-native")>] AnimatedMultiplication() =
            inherit AnimatedInterpolation()


        and [<Import("Animated.AnimatedModulo","react-native")>] AnimatedModulo() =
            inherit AnimatedInterpolation()


        and ParallelConfig =
            obj

        and Mapping =
            U2<obj, AnimatedValue>

        and EventConfig =
            abstract listener: Function option with get, set

        type [<Import("Animated","react-native")>] Globals =
            static member timing with get(): Func<U2<AnimatedValue, AnimatedValueXY>, TimingAnimationConfig, CompositeAnimation> = failwith "JS only" and set(v: Func<U2<AnimatedValue, AnimatedValueXY>, TimingAnimationConfig, CompositeAnimation>): unit = failwith "JS only"
            static member spring with get(): Func<U2<AnimatedValue, AnimatedValueXY>, SpringAnimationConfig, CompositeAnimation> = failwith "JS only" and set(v: Func<U2<AnimatedValue, AnimatedValueXY>, SpringAnimationConfig, CompositeAnimation>): unit = failwith "JS only"
            static member ``parallel`` with get(): Func<ResizeArray<CompositeAnimation>, ParallelConfig, CompositeAnimation> = failwith "JS only" and set(v: Func<ResizeArray<CompositeAnimation>, ParallelConfig, CompositeAnimation>): unit = failwith "JS only"
            static member ``event`` with get(): Func<ResizeArray<Mapping>, EventConfig, Func<obj, unit>> = failwith "JS only" and set(v: Func<ResizeArray<Mapping>, EventConfig, Func<obj, unit>>): unit = failwith "JS only"
            static member View with get(): obj = failwith "JS only" and set(v: obj): unit = failwith "JS only"
            static member Image with get(): obj = failwith "JS only" and set(v: obj): unit = failwith "JS only"
            static member Text with get(): obj = failwith "JS only" and set(v: obj): unit = failwith "JS only"
            static member decay(value: U2<AnimatedValue, AnimatedValueXY>, config: DecayAnimationConfig): CompositeAnimation = failwith "JS only"
            static member add(a: Animated, b: Animated): AnimatedAddition = failwith "JS only"
            static member multiply(a: Animated, b: Animated): AnimatedMultiplication = failwith "JS only"
            static member modulo(a: Animated, modulus: float): AnimatedModulo = failwith "JS only"
            static member delay(time: float): CompositeAnimation = failwith "JS only"
            static member sequence(animations: ResizeArray<CompositeAnimation>): CompositeAnimation = failwith "JS only"
            static member stagger(time: float, animations: ResizeArray<CompositeAnimation>): CompositeAnimation = failwith "JS only"



    module addons =
        type TestModuleStatic =
            abstract verifySnapshot: Func<Func<obj, unit>, unit> with get, set
            abstract markTestPassed: Func<obj, unit> with get, set
            abstract markTestCompleted: Func<unit> with get, set

        and TestModule =
            TestModuleStatic

        type [<Import("addons","react-native")>] Globals =
            static member TestModule with get(): TestModuleStatic = failwith "JS only" and set(v: TestModuleStatic): unit = failwith "JS only"


