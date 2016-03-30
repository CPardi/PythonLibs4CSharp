dll_name = "StdLib.dll"
lib_path = "Lib"

from os.path import join
import sys
sys.path.append(r'C:\Program Files\IronPython 2.7\Lib')
sys.path.append(r'C:\Program Files\IronPython 2.7')
import clr

clr.AddReference('IronPython')
clr.AddReference('IronPython.Modules')
clr.AddReference('Microsoft.Scripting.Metadata')
clr.AddReference('Microsoft.Scripting')
clr.AddReference('Microsoft.Dynamic')
clr.AddReference('mscorlib')
clr.AddReference('System')
clr.AddReference('System.Data')

#
# adapted from os-path-walk-example-3.py

import os, glob
import fnmatch

#Build StdLib.DLL

def get_files_recursive(dir_name):
	files = []
	for (root, directories, files_names) in os.walk(dir_name):
		for file in files_names:
			if(file.endswith(".py")):
				files.append(os.path.join(root, file))
		for dir in directories:
			files.extend(get_files_recursive(os.path.join(root, dir)))
	return files

	
clr.CompileModules(join("..", dll_name), *get_files_recursive(lib_path))
