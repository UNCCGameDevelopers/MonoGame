// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace Microsoft.Xna.Framework.Graphics
{
	public partial class BlendState : GraphicsResource
	{
        private readonly TargetBlendState[] _targetBlendState;

	    private bool _bound;

	    private Color _blendFactor;

	    private int _multiSampleMask;

	    private bool _independentBlendEnable;

	    internal void BindToGraphicsDevice(GraphicsDevice device)
	    {
	        GraphicsDevice = device;
	        _bound = true;
	    }

        internal void ThrowIfBound()
        {
            if (_bound)
                throw new InvalidOperationException("You cannot modify the blend state after it has been bound to the graphics device!");
        }

        /// <summary>
        /// Returns the target specific blend state.
        /// </summary>
        /// <param name="index">The 0 to 3 target blend state index.</param>
        /// <returns>A target blend state.</returns>
        public TargetBlendState this[int index]
        {
            get { return _targetBlendState[index]; }
        }

	    public BlendFunction AlphaBlendFunction
	    {
	        get { return _targetBlendState[0].AlphaBlendFunction; } 
            set
            {
                ThrowIfBound();
                _targetBlendState[0].AlphaBlendFunction = value;
            }
	    }

		public Blend AlphaDestinationBlend
        {
            get { return _targetBlendState[0].AlphaDestinationBlend; }
            set
            {
                ThrowIfBound();
                _targetBlendState[0].AlphaDestinationBlend = value;
            }
        }

		public Blend AlphaSourceBlend
        {
            get { return _targetBlendState[0].AlphaSourceBlend; }
            set
            {
                ThrowIfBound();
                _targetBlendState[0].AlphaSourceBlend = value;
            }
        }

		public BlendFunction ColorBlendFunction
        {
            get { return _targetBlendState[0].ColorBlendFunction; }
            set
            {
                ThrowIfBound();
                _targetBlendState[0].ColorBlendFunction = value;
            }
        }

		public Blend ColorDestinationBlend
        {
            get { return _targetBlendState[0].ColorDestinationBlend; }
            set
            {
                ThrowIfBound();
                _targetBlendState[0].ColorDestinationBlend = value;
            }
        }

		public Blend ColorSourceBlend
        {
            get { return _targetBlendState[0].ColorSourceBlend; }
            set
            {
                ThrowIfBound();
                _targetBlendState[0].ColorSourceBlend = value;
            }
        }

		public ColorWriteChannels ColorWriteChannels
        {
            get { return _targetBlendState[0].ColorWriteChannels; }
            set
            {
                ThrowIfBound();
                _targetBlendState[0].ColorWriteChannels = value;
            }
        }

		public ColorWriteChannels ColorWriteChannels1
        {
            get { return _targetBlendState[1].ColorWriteChannels; }
            set
            {
                ThrowIfBound();
                _targetBlendState[1].ColorWriteChannels = value;
            }
        }

		public ColorWriteChannels ColorWriteChannels2
        {
            get { return _targetBlendState[2].ColorWriteChannels; }
            set
            {
                ThrowIfBound();
                _targetBlendState[2].ColorWriteChannels = value;
            }
        }

		public ColorWriteChannels ColorWriteChannels3
        {
            get { return _targetBlendState[3].ColorWriteChannels; }
            set
            {
                ThrowIfBound();
                _targetBlendState[3].ColorWriteChannels = value;
            }
        }

	    public Color BlendFactor
	    {
	        get { return _blendFactor; }
            set
            {
                ThrowIfBound();
                _blendFactor = value;
            }
	    }

        public int MultiSampleMask
        {
            get { return _multiSampleMask; }
            set
            {
                ThrowIfBound();
                _multiSampleMask = value;
            }
        }

        /// <summary>
        /// Enables use of the per-target blend states.
        /// </summary>
        public bool IndependentBlendEnable
        {
            get { return _independentBlendEnable; }
            set
            {
                ThrowIfBound();
                _independentBlendEnable = value;
            }
        }

		private static readonly Utilities.ObjectFactoryWithReset<BlendState> _additive;
        private static readonly Utilities.ObjectFactoryWithReset<BlendState> _alphaBlend;
        private static readonly Utilities.ObjectFactoryWithReset<BlendState> _nonPremultiplied;
        private static readonly Utilities.ObjectFactoryWithReset<BlendState> _opaque;

        public static BlendState Additive { get { return _additive.Value; } }
        public static BlendState AlphaBlend { get { return _alphaBlend.Value; } }
        public static BlendState NonPremultiplied { get { return _nonPremultiplied.Value; } }
        public static BlendState Opaque { get { return _opaque.Value; } }
        
        public BlendState() 
        {
            _targetBlendState = new TargetBlendState[4];
            _targetBlendState[0] = new TargetBlendState(this);
            _targetBlendState[1] = new TargetBlendState(this);
            _targetBlendState[2] = new TargetBlendState(this);
            _targetBlendState[3] = new TargetBlendState(this);

			_blendFactor = Color.White;
            _multiSampleMask = Int32.MaxValue;
            _independentBlendEnable = false;
        }

	    private BlendState(string name, Blend sourceBlend, Blend destinationBlend)
            : this()
	    {
	        Name = name;
	        ColorSourceBlend = sourceBlend;
	        AlphaSourceBlend = sourceBlend;
	        ColorDestinationBlend = destinationBlend;
	        AlphaDestinationBlend = destinationBlend;
	        _bound = true;
	    }
		
		static BlendState() 
        {
            _additive = new Utilities.ObjectFactoryWithReset<BlendState>(() => 
                new BlendState("BlendState.Additive", Blend.SourceAlpha, Blend.One));
			
			_alphaBlend = new Utilities.ObjectFactoryWithReset<BlendState>(() =>
                new BlendState("BlendState.AlphaBlend", Blend.One, Blend.InverseSourceAlpha));
			
			_nonPremultiplied = new Utilities.ObjectFactoryWithReset<BlendState>(() =>
                new BlendState("BlendState.NonPremultiplied", Blend.SourceAlpha, Blend.InverseSourceAlpha));
			
			_opaque = new Utilities.ObjectFactoryWithReset<BlendState>(() =>
                new BlendState("BlendState.Opaque", Blend.One, Blend.Zero));
		}

        internal static void ResetStates()
        {
            _additive.Reset();
            _alphaBlend.Reset();
            _nonPremultiplied.Reset();
            _opaque.Reset();
        }
	}
}

