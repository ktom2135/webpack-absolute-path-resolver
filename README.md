# webpack-absolute-path-resolver

This is a .net console project use for replace webpack alias to replace relatively path to absolute path

e.g:

orginal:

```
 import { componenta } from '../path-a/component-a';

 import { componenta } from '../../../path-a/component-a';


```

Expect:

```
 import { componenta } from '@componet-src/path-a/component-a';
...
 import { componenta } from '@componet-src/path-a/component-a';

```




