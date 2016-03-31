# Modifications

The following modifications were made to ensure compatibility with Iron Python.

 * The attribute list extension (markdown\extensions\attr_list.py) has a dependency on `re.Scanner`. However, Iron Python does not implement this class and so this dependency has been removed and replaced by a simplified implementation.