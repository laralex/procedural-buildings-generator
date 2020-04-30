﻿using g3;
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace ProceduralBuildingsGeneration
{
    public class FileExporter : IExporter
    {
        public bool ObjExport(Model3d model, ExportParameters parameters)
        {
            parameters.ModelFormat = ModelFormat.OBJ;
            var exportData = new List<WriteMesh> { new WriteMesh(model.Mesh) };
            return Export(exportData, parameters);
        }

        public bool StlExport(Model3d model, ExportParameters parameters)
        {
            parameters.ModelFormat = ModelFormat.STL;
            var exportData = new List<WriteMesh> { new WriteMesh(model.Mesh) };
            return Export(exportData, parameters);
        }
        private bool Export(List<WriteMesh> data, ExportParameters parameters)
        {
            var writeOptions = WriteOptions.Defaults;
            writeOptions.AsciiHeaderFunc = () => "Generated by Procedural Buildings Generator by Alexey Larionov";

            var fileParameters = parameters as FileExportParameters;
            var ioResult = new StandardMeshWriter().Write(fileParameters.FilePath, data, writeOptions);
            if (ioResult.code != IOCode.Ok)
            {
                return false;
            }
            return true;
        }
    }
}
