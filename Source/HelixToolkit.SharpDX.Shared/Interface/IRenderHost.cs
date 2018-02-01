﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderHost.cs" company="Helix Toolkit">
//   Copyright (c) 2018 Helix Toolkit contributors
// </copyright>
// <summary>
//   This technique is used for the entire render pass 
//   by all Element3D if not specified otherwise in
//   the elements itself
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !NETFX_CORE
namespace HelixToolkit.Wpf.SharpDX
#else
namespace HelixToolkit.UWP
#endif
{
    using System;

    using global::SharpDX;

    using global::SharpDX.Direct3D11;

    using Utilities;
    using Model;
    using Core2D;
    /// <summary>
    /// 
    /// </summary>
    public interface IRenderHost : IDisposable, IGUID
    {
        /// <summary>
        /// Fired whenever an exception occurred on this object.
        /// </summary>
        event EventHandler<RelayExceptionEventArgs> ExceptionOccurred;
        /// <summary>
        /// Occurs when [on new render target texture].
        /// </summary>
        event EventHandler<Texture2D> OnNewRenderTargetTexture;
        /// <summary>
        /// Occurs when [start render loop].
        /// </summary>
        event EventHandler<bool> StartRenderLoop;
        /// <summary>
        /// Occurs when [stop render loop].
        /// </summary>
        event EventHandler<bool> StopRenderLoop;
        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <value>
        /// The device.
        /// </value>
        Device Device { get; }
        /// <summary>
        /// Gets the device2d.
        /// </summary>
        /// <value>
        /// The device2d.
        /// </value>
        global::SharpDX.Direct2D1.Device Device2D { get; }
        /// <summary>
        /// Gets or sets the color of the clear.
        /// </summary>
        /// <value>
        /// The color of the clear.
        /// </value>
        Color4 ClearColor { set; get; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is shadow map enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is shadow map enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsShadowMapEnabled { set; get; }
#if MSAA
        MSAALevel MSAA { get; set; }
#endif        
        /// <summary>
        /// Gets or sets the viewport.
        /// </summary>
        /// <value>
        /// The viewport.
        /// </value>
        IViewport3DX Viewport { get; set; }
        /// <summary>
        /// Gets the render context.
        /// </summary>
        /// <value>
        /// The render context.
        /// </value>
        IRenderContext RenderContext { get; }
        /// <summary>
        /// Sets the default render targets.
        /// </summary>
        /// <param name="clear">if set to <c>true</c> [clear].</param>
        void SetDefaultRenderTargets(bool clear = true);
        /// <summary>
        /// Gets or sets the effects manager.
        /// </summary>
        /// <value>
        /// The effects manager.
        /// </value>
        IEffectsManager EffectsManager { get; set; }

        /// <summary>
        /// This technique is used for the entire render pass 
        /// by all Element3D if not specified otherwise in
        /// the elements itself
        /// </summary>
        IRenderTechnique RenderTechnique { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is deferred lighting.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deferred lighting; otherwise, <c>false</c>.
        /// </value>
        bool IsDeferredLighting { get; }
        /// <summary>
        /// Gets the actual height.
        /// </summary>
        /// <value>
        /// The actual height.
        /// </value>
        double ActualHeight { get; }
        /// <summary>
        /// Gets the actual width.
        /// </summary>
        /// <value>
        /// The actual width.
        /// </value>
        double ActualWidth { get; }

        /// <summary>
        /// Indicates if DPFCanvas busy on rendering.
        /// </summary>
        bool IsBusy { get; }
        /// <summary>
        /// Gets or sets a value indicating whether [enable render frustum].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable render frustum]; otherwise, <c>false</c>.
        /// </value>
        bool EnableRenderFrustum { set; get; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable sharing model mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable sharing model mode]; otherwise, <c>false</c>.
        /// </value>
        bool EnableSharingModelMode { set; get; }
        /// <summary>
        /// Gets or sets the shared model container.
        /// </summary>
        /// <value>
        /// The shared model container.
        /// </value>
        IModelContainer SharedModelContainer { set; get; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is rendering.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is rendering; otherwise, <c>false</c>.
        /// </value>
        bool IsRendering { set; get; }
        /// <summary>
        /// Gets the color buffer view.
        /// </summary>
        /// <value>
        /// The color buffer view.
        /// </value>
        RenderTargetView ColorBufferView { get; }
        /// <summary>
        /// Gets the depth stencil buffer view.
        /// </summary>
        /// <value>
        /// The depth stencil buffer view.
        /// </value>
        DepthStencilView DepthStencilBufferView { get; }
        /// <summary>
        /// Gets the d2d target.
        /// </summary>
        /// <value>
        /// The d2d target.
        /// </value>
        ID2DTargetProxy D2DTarget { get; }
        /// <summary>
        /// Starts the d3 d.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        void StartD3D(double width, double height);
        /// <summary>
        /// Ends the d3 d.
        /// </summary>
        void EndD3D();
        /// <summary>
        /// Updates the and render.
        /// </summary>
        void UpdateAndRender();
        /// <summary>
        /// Invalidates the render.
        /// </summary>
        void InvalidateRender();
        /// <summary>
        /// Resizes
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        void Resize(double width, double height);
        /// <summary>
        /// Gets or sets a value indicating whether [show statistics].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show statistics]; otherwise, <c>false</c>.
        /// </value>
        RenderDetail ShowRenderDetail { set; get; }
        IRenderStatistics RenderStatistics { get; }
    }
}