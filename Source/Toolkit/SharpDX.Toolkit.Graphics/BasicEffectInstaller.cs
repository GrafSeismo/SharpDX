﻿// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SharpDX.Toolkit.Graphics
{
    /// <summary>
    /// Implementation of the <see cref="IEffectInstaller"/> for the <see cref="BasicEffect"/>.
    /// </summary>
    /// <remarks>
    /// This effect installer is similar to the default behavior of XNA with <see cref="BasicEffect"/>.
    /// </remarks>
    public class BasicEffectInstaller : EffectInstallerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EffectInstallerBase" /> class.
        /// </summary>
        /// <param name="services">The services.</param>
        public BasicEffectInstaller(IServiceRegistry services)
            : base(services)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EffectInstallerBase" /> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public BasicEffectInstaller(GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="BasicEffect"/>, overridable in case a user would want to subclass <see cref="BasicEffect"/>.
        /// </summary>
        /// <returns>A new instance of BasicEffect.</returns>
        protected virtual BasicEffect CreateBasicEffect()
        {
            return new BasicEffect(GraphicsDevice);
        }

        /// <summary>Implements this method to process a <see cref="ModelMeshPart" />.</summary>
        /// <param name="model">The model.</param>
        /// <param name="meshPart">The mesh part.</param>
        /// <returns>Effect to be associated to the <see cref="ModelMeshPart" />.</returns>
        protected override Effect Process(Model model, ModelMeshPart meshPart)
        {
            var effect = CreateBasicEffect();

            var material = meshPart.Material;

            // Setup ColorDiffuse
            if (material.HasProperty(MaterialKeysBase.ColorDiffuse))
            {
                effect.DiffuseColor = material.GetProperty(MaterialKeysBase.ColorDiffuse);
            }

            // Setup ColorSpecular
            if (material.HasProperty(MaterialKeysBase.ColorSpecular))
            {
                effect.SpecularColor = material.GetProperty(MaterialKeysBase.ColorSpecular);
            }

            // Setup ColorEmissive
            if (material.HasProperty(MaterialKeysBase.ColorEmissive))
            {
                effect.EmissiveColor = material.GetProperty(MaterialKeysBase.ColorEmissive);
            }

            if (material.HasProperty(MaterialKeys.DiffuseTexture))
            {
                var diffuseTextureStack = material.GetProperty(MaterialKeys.DiffuseTexture);
                if (diffuseTextureStack.Count > 0)
                {
                    var diffuseTexture = diffuseTextureStack[0];
                    effect.Texture = (Texture2DBase)diffuseTexture.Texture;
                    effect.TextureEnabled = true;
                }
            }

            return effect;
        }
    }
}